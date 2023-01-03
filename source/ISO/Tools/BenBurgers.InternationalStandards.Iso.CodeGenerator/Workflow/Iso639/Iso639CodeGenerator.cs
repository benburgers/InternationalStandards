/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.CodeGenerator.Common;
using BenBurgers.InternationalStandards.Iso.CodeGenerator.Configuration.Iso639;
using BenBurgers.InternationalStandards.Iso.IO.Iso639;
using BenBurgers.InternationalStandards.Iso.Iso639;
using BenBurgers.InternationalStandards.Iso.Iso639.Attributes;
using Microsoft.CSharp;
using Microsoft.Extensions.Logging;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;

namespace BenBurgers.InternationalStandards.Iso.CodeGenerator.Workflow.Iso639;

/// <summary>
/// Generates code for the ISO 639 standard.
/// </summary>
internal static class Iso639CodeGenerator
{
    private static readonly CodeTypeReference Iso639Part1Attribute = new(typeof(Iso639Part1Attribute));
    private static readonly CodeTypeReference Iso639Part2Attribute = new(typeof(Iso639Part2Attribute));
    private static readonly CodeTypeReference Iso639Part3Attribute = new(typeof(Iso639Part3Attribute));

    private static async Task<IReadOnlyCollection<Iso639Model>> PrepareModelsAsync(
        Iso639Options options,
        CancellationToken cancellationToken = default)
    {
        /* Part 3 Code Table */
        using var part3CodeTableFileStream = File.OpenRead(options.Part3CodeTableFileName);
        using var part3CodeTableReader = new Iso639TableReader<Iso639Part3CodeTableRecord>(part3CodeTableFileStream);
        var part3CodeTableRecords = await part3CodeTableReader.ReadAllAsync(cancellationToken);

        /* Part 3 Name Index */
        using var part3NameIndexFileStream = File.OpenRead(options.Part3NameIndexFileName);
        using var part3NameIndexReader = new Iso639TableReader<Iso639Part3NameIndexRecord>(part3NameIndexFileStream);
        var part3NameIndexRecords = await part3NameIndexReader.ReadAllAsync(cancellationToken);

        /* Part 3 join codes and names */
        var part3Models =
            part3CodeTableRecords
                .Join(
                    part3NameIndexRecords,
                    code => code.Part3!.Value,
                    name => name.Id.Value,
                    (code, name) =>
                        new Iso639Model(
                            code.Part1,
                            code.Part2T,
                            code.Part2B,
                            code.Part3,
                            code.Scope,
                            code.LanguageType,
                            code.RefName,
                            name.PrintName,
                            name.InvertedName))
                .GroupBy(m => m.Part3!.Value)
                .Select(g =>
                {
                    var first = g.First();
                    return first with
                    {
                        RefName = string.Join(", ", g.Select(m => m.RefName)),
                        PrintName = string.Join(", ", g.Select(m => m.PrintName)),
                        InvertedName = string.Join(", ", g.Select(m => m.InvertedName))
                    };
                })
                .ToList();

        /* Part 3 deduplicate */
        var part3Duplicates =
            part3Models
                .Select((m, i) => (Model: m, Index: i))
                .Where(mi =>
                    part3Models
                        .Select((m, i) => (Model: m, Index: i))
                        .Any(mi2 => mi2.Model.InvertedName == mi.Model.InvertedName && mi.Index != mi2.Index))
                .ToArray();
        var part3DuplicateCounter = 0;
        foreach (var (model, index) in part3Duplicates.Skip(1))
        {
            part3Models[index] = part3Models[index] with { InvertedName = model.InvertedName + part3DuplicateCounter.ToString() };
            ++part3DuplicateCounter;
        }

        return part3Models;
    }

    /// <summary>
    /// Generates code for the ISO 639 standard.
    /// </summary>
    /// <param name="options">
    /// The code generation options.
    /// </param>
    /// <param name="logger">
    /// Logs messages for debugging and troubleshooting.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    internal static async Task GenerateAsync(
        Iso639Options options,
        ILogger logger,
        CancellationToken cancellationToken = default)
    {
        using var loggerScope = logger.BeginScope("ISO 639 language codes");
        logger.LogInformation("Generation started.");

        logger.LogDebug("Preparing models from imported files.");
        var models = await PrepareModelsAsync(options, cancellationToken);

        logger.LogDebug("Generating to project in folder '{ProjectFolder}'.", options.ProjectFolder);
        var projectDirectory = new DirectoryInfo(options.ProjectFolder);

        logger.LogDebug("Generating codes.");
        var iso639CodeFileName = Path.Combine(projectDirectory.FullName, "Iso639", "Iso639Code.cs");
        using var iso639CodeFile = File.Open(iso639CodeFileName, FileMode.Create, FileAccess.Write);
        using var iso639StreamWriter = new StreamWriter(iso639CodeFile);
        using var iso639IndentedTextWriter = new IndentedTextWriter(iso639StreamWriter);

        const string Namespace = "BenBurgers.InternationalStandards.Iso.Iso639";
        var iso639CompileUnit = new CodeCompileUnit();
        var iso639Namespace = new CodeNamespace(Namespace);
        iso639Namespace.Comments.AddRange(CopyrightNotice.Instance);
        iso639Namespace.Imports.Add(new CodeNamespaceImport($"{Namespace}.Attributes"));
        iso639Namespace.Types.Add(Enum(options.Part3Effective, models));
        iso639CompileUnit.Namespaces.Add(iso639Namespace);

        logger.LogDebug("Writing generated code to file '{iso639CodeFileName}'.", iso639CodeFileName);
        var codeProvider = new CSharpCodeProvider();
        codeProvider.GenerateCodeFromCompileUnit(iso639CompileUnit, iso639IndentedTextWriter, new CodeGeneratorOptions());
        iso639IndentedTextWriter.Close();

        logger.LogInformation("Generation completed.");
    }

    private static readonly Regex SanitizeRegex = new(@"[ \-,()'\.’\[\]]");
    private static string NormalizeName(string name)
    {
        static string CapitalizeFirstLetter(string value)
        {
            return
                value switch
                {
                    { Length: 0 } => value,
                    { Length: 1 } => new string(char.ToUpperInvariant(value[0]), 1),
                    { Length: > 1 } => char.ToUpperInvariant(value[0]) + value.Substring(1)
                };
        }

        var parts = name.Trim().Split(" ").Select(p => CapitalizeFirstLetter(SanitizeRegex.Replace(p, "_"))).ToArray();
        return string.Join("", parts);
    }

    private static CodeTypeDeclaration Enum(DateTimeOffset effectiveDate, IEnumerable<Iso639Model> models)
    {
        var typeDeclaration = new CodeTypeDeclaration("Iso639Code") { IsEnum = true };
        typeDeclaration.Comments.AddRange(EnumDocumentation(effectiveDate));
        typeDeclaration.Members.AddRange(EnumFields(models).ToArray());
        return typeDeclaration;
    }

    private static CodeCommentStatementCollection EnumDocumentation(DateTimeOffset iso639EffectiveDate) =>
        new(
            new CodeCommentStatement[]
            {
                new("<summary>An <a href=\"https://www.iso.org/iso-639-language-codes.html\">ISO 639</a> Language Code.</summary>", true),
                new("<remarks>", true),
                new("<para>The <a href=\"https://www.austrian-standards.at/en\">Austrian Standards</a> is the Maintenace Agency of ISO 639-1 codes.<br />Only they can designate ISO 639-1 codes. This work is a derivation and enhancement and anything other than ISO 639-1 is the responsibility of the respective copyright holders.</para>", true),
                new("<para>The <a href=\"https://www.loc.gov/standards/iso639-2/\">Library of Congress</a> is the Maintenance Agency of ISO 639-2 codes.<br />Only they can designate ISO 639-2 codes. This work is a derivation and enhancement and anything other than ISO 639-2 is the responsibility of the respective copyright holders.</para>", true),
                new($"<para>The <a href=\"https://www.iso639-3.sil.org\">SIL International</a> is the Maintenance Agency of ISO 639-3 codes.<br />Only they can designate ISO 639-3 codes. This work is a derivation and enhancement and anything other than ISO 639-3 is the responsibility of the respective copyright holders.<br />The ISO 639-3 codes are effective from {iso639EffectiveDate:D}.</para>", true),
                new("<para>If you notice any mistake in this work, please create a Pull Request or notify the repository owner or a contributor as soon as possible.</para>", true),
                new("<para>Extension methods from <see cref=\"Iso639CodeExtensions\" /> enable conversion from and to <see cref=\"Iso639Code\" />.<br />To convert from an Alpha code in a <see cref=\"string\" />, use the extension method <see cref=\"Iso639CodeExtensions.ToIso639(string, bool)\" />.</para>", true),
                new("<para>The ISO 639 standard does not define numerical values, so the value of <see cref=\"Iso639Code\" /> is the ISO 639-3 Alpha-3 code encoded as ASCII.<br />If ISO 639-3 for a particular value is not defined, then fallback to ISO 639-2, then ISO 639-1.</para>", true),
                new("</remarks>", true)
            }
        );

    private static CodeMemberField EnumFieldDoc(CodeMemberField field, string name, string value)
    {
        var valueDescription = string.IsNullOrWhiteSpace(value) ? "N/A" : value;
        field.Comments.Add(new CodeCommentStatement($"\t\t<item><term>{name}</term><description>{valueDescription}</description></item>", true));
        return field;
    }

    private static IEnumerable<CodeTypeMember> EnumFields(IEnumerable<Iso639Model> models)
    {
        foreach (var model in models)
        {
            if (model.Part1 is not { } && model.Part2T is not { } && model.Part2B is not { } && model.Part3 is not { })
                throw new Exception($"No ISO 639 part found for '{model.PrintName}'.");
            var member =
                new CodeMemberField
                {
                    Name = NormalizeName(model.InvertedName ?? model.PrintName ?? model.RefName ?? $"Iso639_{model.PrintName}"),
                    InitExpression = new CodePrimitiveExpression((model.Part3!.Value[0] << 16) + (model.Part3!.Value[1] << 8) + model.Part3!.Value[2])
                };

            member.Comments.Add(new CodeCommentStatement($"<summary>{model.PrintName}</summary>", true));
            member.Comments.Add(new CodeCommentStatement("<remarks>", true));
            member.Comments.Add(new CodeCommentStatement("\t<list type=\"table\">", true));
            EnumFieldDoc(member, "ISO 639-1", model.Part1?.Value ?? "N/A");
            EnumFieldDoc(member, "ISO 639-2T", model.Part2T?.Value ?? "N/A");
            EnumFieldDoc(member, "ISO 639-2B", model.Part2B?.Value ?? "N/A");
            EnumFieldDoc(member, "ISO 639-3", model.Part3?.Value ?? "N/A");
            EnumFieldDoc(member, "Scope", model.Scope.ToString());
            EnumFieldDoc(member, "Language Type", model.LanguageType.ToString());
            member.Comments.Add(new CodeCommentStatement("\t</list>", true));
            member.Comments.Add(new CodeCommentStatement("</remarks>", true));

            if (model.Part1?.Value is { } part1)
                member.CustomAttributes.Add(new CodeAttributeDeclaration(nameof(Iso639Part1Attribute), new CodeAttributeArgument[] { new(new CodePrimitiveExpression(part1)) }));
            if (model.Part2T?.Value is { } part2T && model.Part2B?.Value is { } part2B)
                member.CustomAttributes.Add(new CodeAttributeDeclaration(nameof(Iso639Part2Attribute), new CodeAttributeArgument[] { new(new CodePrimitiveExpression(part2T)), new(new CodePrimitiveExpression(part2B)) }));
            if (model.Part3?.Value is { } part3)
                member.CustomAttributes.Add(new CodeAttributeDeclaration(nameof(Iso639Part3Attribute), new CodeAttributeArgument[] { new(new CodePrimitiveExpression(part3)) }));
            member.CustomAttributes.Add(new CodeAttributeDeclaration(nameof(Iso639ScopeAttribute), new CodeAttributeArgument[] { new(new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(typeof(Iso639Scope)), model.Scope.ToString())) }));
            member.CustomAttributes.Add(new CodeAttributeDeclaration(nameof(Iso639LanguageTypeAttribute), new CodeAttributeArgument[] { new(new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(typeof(Iso639LanguageType)), model.LanguageType.ToString())) }));

            yield return member;
        }
    }
}
