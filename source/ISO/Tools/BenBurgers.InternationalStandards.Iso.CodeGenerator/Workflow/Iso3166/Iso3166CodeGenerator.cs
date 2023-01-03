/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.CodeGenerator.Common;
using BenBurgers.InternationalStandards.Iso.CodeGenerator.Configuration.Iso3166;
using BenBurgers.InternationalStandards.Iso.IO.Iso3166;
using BenBurgers.InternationalStandards.Iso.Iso3166;
using BenBurgers.InternationalStandards.Iso.Iso3166.Attributes;
using BenBurgers.InternationalStandards.Iso.Iso639;
using Microsoft.CSharp;
using Microsoft.Extensions.Logging;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;

namespace BenBurgers.InternationalStandards.Iso.CodeGenerator.Workflow.Iso3166;

internal static partial class Iso3166CodeGenerator
{
    private static readonly CodeTypeReference Iso3166AlphaAttribute = new(typeof(Iso3166AlphaAttribute));
    private static readonly CodeTypeReference Iso3166IndependentAttribute = new(typeof(Iso3166IndependentAttribute));
    private static readonly CodeTypeReference Iso3166StatusAttribute = new(typeof(Iso3166StatusAttribute));

    private sealed record Iso3166Models(
        DateTimeOffset Generated,
        IReadOnlySet<Iso3166Model> Models);

    private static async Task<Iso3166Models> PrepareModelsAsync(
        Iso3166Options options,
        CancellationToken cancellationToken = default)
    {
        using var fileStream = File.OpenRead(options.XmlFileName);
        using var iso3166XmlReader = new Iso3166XmlReader(fileStream);
        var dataSet = await iso3166XmlReader.ReadAsync(cancellationToken);
        return new Iso3166Models(
            dataSet.Generated,
            dataSet
                .Countries
                .OrderBy(c => c.Id)
                .Select(c => new Iso3166Model(
                    c.Numeric,
                    c.Alpha2,
                    c.Alpha3,
                    c.Independent,
                    c.Status,
                    c.FullName.ToGlobalizedString(Iso639Code.English),
                    c.ShortName.ToGlobalizedString(Iso639Code.English),
                    c.ShortNameUpperCase.ToGlobalizedString(Iso639Code.English)))
                .ToHashSet());
    }

    internal static async Task GenerateAsync(
        Iso3166Options options,
        ILogger logger,
        CancellationToken cancellationToken = default)
    {
        using var loggerScope = logger.BeginScope("ISO 3166 country codes");
        logger.LogInformation("Generation started.");

        logger.LogDebug("Preparing models from imported file.");
        var models = await PrepareModelsAsync(options, cancellationToken);

        logger.LogDebug("Generating to project in folder '{ProjectFolder}'.", options.ProjectFolder);
        var projectDirectory = new DirectoryInfo(options.ProjectFolder);

        logger.LogDebug("Generating codes.");
        var iso3166CodeFileName = Path.Combine(projectDirectory.FullName, "Iso3166", "Iso3166Code.cs");
        using var iso3166CodeFile = File.Open(iso3166CodeFileName, FileMode.Create, FileAccess.Write);
        using var iso3166StreamWriter = new StreamWriter(iso3166CodeFile);
        using var iso3166IndentedTextWriter = new IndentedTextWriter(iso3166StreamWriter);

        const string Namespace = "BenBurgers.InternationalStandards.Iso.Iso3166";
        var iso3166CompileUnit = new CodeCompileUnit();
        var iso3166Namespace = new CodeNamespace(Namespace);
        iso3166Namespace.Comments.AddRange(CopyrightNotice.Instance);
        iso3166Namespace.Imports.Add(new CodeNamespaceImport($"{Namespace}.Attributes"));
        iso3166Namespace.Imports.Add(new CodeNamespaceImport(typeof(Iso639Code).Namespace!));
        iso3166Namespace.Types.Add(Enum(models.Generated, models.Models));
        iso3166CompileUnit.Namespaces.Add(iso3166Namespace);

        logger.LogDebug("Writing generated code to file '{iso3166CodeFileName}'.", iso3166CodeFileName);
        var codeProvider = new CSharpCodeProvider();
        codeProvider.GenerateCodeFromCompileUnit(iso3166CompileUnit, iso3166IndentedTextWriter, new CodeGeneratorOptions());
        iso3166IndentedTextWriter.Close();

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

        if (name.EndsWith(" (the)"))
            name = name[..^" (the)".Length];
        var parts = name.Trim().Split(" ").Select(p => CapitalizeFirstLetter(SanitizeRegex.Replace(p, "_"))).ToArray();
        return string.Join("", parts).TrimEnd('_');
    }

    private static CodeTypeDeclaration Enum(DateTimeOffset generated, IEnumerable<Iso3166Model> models)
    {
        var typeDeclaration = new CodeTypeDeclaration("Iso3166Code") { IsEnum = true };
        typeDeclaration.Comments.AddRange(EnumDocumentation(generated));
        typeDeclaration.Members.AddRange(EnumFields(models).ToArray());
        return typeDeclaration;
    }

    private static CodeMemberField EnumFieldDoc(CodeMemberField field, string name, string value)
    {
        field.Comments.Add(new CodeCommentStatement($"\t\t<item><term>{name}</term><description>{value}</description></item>", true));
        return field;
    }

    private static IEnumerable<CodeTypeMember> EnumFields(IEnumerable<Iso3166Model> models)
    {
        foreach (var model in models)
        {
            // Field
            var member =
                new CodeMemberField
                {
                    Name = NormalizeName(model.ShortName[Iso639Code.English]!),
                    InitExpression = new CodePrimitiveExpression(model.Numeric)
                };

            // Documentation
            var fullName = model.FullName.ToString();
            var name = string.IsNullOrWhiteSpace(fullName) ? model.ShortName.ToString() : fullName;
            member.Comments.Add(new CodeCommentStatement($"<summary>{name}</summary>", true));
            member.Comments.Add(new CodeCommentStatement($"<remarks>", true));
            member.Comments.Add(new CodeCommentStatement($"\t<list type=\"table\">", true));
            EnumFieldDoc(member, "Alpha-2", model.Alpha2.ToString());
            EnumFieldDoc(member, "Alpha-3", model.Alpha3.ToString());
            EnumFieldDoc(member, "Numeric", model.Numeric.ToString("D3"));
            EnumFieldDoc(member, "Independent", model.Independent ? "Yes" : "No");
            EnumFieldDoc(member, "Status", model.Status switch
            {
                Iso3166Status.OfficiallyAssigned => "Officially assigned",
                Iso3166Status.ExceptionallyReserved => "Exceptionally reserved",
                Iso3166Status.TransitionallyReserved => "Transitionally reserved",
                Iso3166Status.IndeterminatelyReserved => "Indeterminately reserved",
                Iso3166Status.FormerlyUsed => "Formerly used",
                Iso3166Status.Unassigned => "Unassigned",
                _ => string.Empty
            });
            member.Comments.Add(new CodeCommentStatement($"\t</list>", true));
            member.Comments.Add(new CodeCommentStatement("</remarks>", true));

            // Attributes
            var alpha = new CodeAttributeDeclaration(
                nameof(Iso3166AlphaAttribute),
                new CodeAttributeArgument(new CodePrimitiveExpression(model.Alpha2.ToString())),
                new CodeAttributeArgument(new CodePrimitiveExpression(model.Alpha3.ToString())));
            var independent = new CodeAttributeDeclaration(
                nameof(Iso3166IndependentAttribute),
                new CodeAttributeArgument(new CodePrimitiveExpression(model.Independent)));
            var status = new CodeAttributeDeclaration(
                nameof(Iso3166StatusAttribute),
                new CodeAttributeArgument(
                    new CodeFieldReferenceExpression(
                        new CodeTypeReferenceExpression(
                            new CodeTypeReference(nameof(Iso3166Status))),
                        model.Status.ToString())));
            var fullNameAttributes =
                model
                    .FullName
                    .Select(fna =>
                        new CodeAttributeDeclaration(
                            nameof(Iso3166FullNameAttribute),
                            new CodeAttributeArgument(
                                new CodeFieldReferenceExpression(
                                    new CodeTypeReferenceExpression(
                                        new CodeTypeReference(nameof(Iso639Code))),
                                    fna.Key.ToString())),
                            new CodeAttributeArgument(new CodePrimitiveExpression(fna.Value!))))
                    .ToArray();
            var shortNameAttributes =
                model
                    .ShortName
                    .Select(sna =>
                        new CodeAttributeDeclaration(
                            nameof(Iso3166ShortNameAttribute),
                            new CodeAttributeArgument(
                                new CodeFieldReferenceExpression(
                                    new CodeTypeReferenceExpression(
                                        new CodeTypeReference(nameof(Iso639Code))),
                                    sna.Key.ToString())),
                            new CodeAttributeArgument(new CodePrimitiveExpression(sna.Value!))))
                    .ToArray();
            var shortNameUpperCaseAttributes =
                model
                    .ShortNameUpperCase
                    .Select(snua =>
                        new CodeAttributeDeclaration(
                            nameof(Iso3166ShortNameUpperCaseAttribute),
                            new CodeAttributeArgument(
                                new CodeFieldReferenceExpression(
                                    new CodeTypeReferenceExpression(
                                        new CodeTypeReference(nameof(Iso639Code))),
                                    snua.Key.ToString())),
                            new CodeAttributeArgument(new CodePrimitiveExpression(snua.Value!))))
                    .ToArray();
            var attributes =
                new[] { alpha, independent, status }
                    .Concat(fullNameAttributes)
                    .Concat(shortNameAttributes)
                    .Concat(shortNameUpperCaseAttributes)
                    .ToArray();

            member
                .CustomAttributes
                .AddRange(attributes);

            yield return member;
        }
    }

    private static CodeCommentStatementCollection EnumDocumentation(DateTimeOffset generated) =>
        new(
            new CodeCommentStatement[]
            {
                new(
@"<summary>
    An <a href=""https://www.iso.org/iso-3166-country-codes.html"">ISO 3166</a> Country Code.
 </summary>", true),
                new(
@$"<remarks>
    <para>
        The <a href=""https://www.iso.org/iso-3166-country-codes.html"">ISO 3166 Maintenance Agency</a> is the sole authority of ISO 3166 codes.
        Only they can designate ISO 3166 codes. This work is a derivation and enhancement and anything other than ISO 3166 is the responsibility of the respective copyright holders.
    </para>
    <para>
        If you notice any mistake in this work, please create a Pull Request or notify the repository owner or a contributor as soon as possible.
    </para>
    <para>
        Extension methods from <see cref=""Iso3166CodeExtensions"" /> enable conversion from and to <see cref=""Iso3166Code"" />.<br />
        To convert from an Alpha code in a <see cref=""string"" />, use the extension method <see cref=""Iso3166CodeExtensions.ToIso3166(string)"" />.
    </para>
    <para>
        The codes were generated at {generated:F}.
    </para>
  </remarks>", true)
            });
}
