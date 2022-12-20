/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.CodeGenerator.Common;
using BenBurgers.InternationalStandards.Iso.CodeGenerator.Configuration.Iso4217;
using BenBurgers.InternationalStandards.Iso.IO.Iso4217;
using BenBurgers.InternationalStandards.Iso.Iso4217;
using BenBurgers.InternationalStandards.Iso.Iso4217.Attributes;
using Microsoft.CSharp;
using Microsoft.Extensions.Logging;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;

namespace BenBurgers.InternationalStandards.Iso.CodeGenerator.Workflow.Iso4217;

/// <summary>
/// Generates code for the ISO 4217 standard.
/// </summary>
internal static class Iso4217CodeGenerator
{
    private static readonly CodeTypeReference Iso4217EntityAttribute = new(typeof(Iso4217EntityAttribute));

    private sealed record ModelIndex(
        Iso4217Model Model,
        int Index);
    private sealed record Iso4217Models(
        DateOnly Published,
        IReadOnlyCollection<Iso4217Model> Models);

    private static async Task<Iso4217Models> PrepareModelsAsync(
        Iso4217Options options,
        CancellationToken cancellationToken = default)
    {
        /* List One codes */
        using var fileStream = File.OpenRead(options.ListOneFileName);
        using var iso4217ListOneXmlReader = new Iso4217ListOneXmlReader(fileStream);
        var dataSet = await iso4217ListOneXmlReader.ReadAsync(cancellationToken);

        /* List One models */
        var listOneModels =
            dataSet
                .Table
                .Entries
                .GroupBy(e => e.Currency?.Value)
                .Select(g =>
                {
                    var first = g.First();
                    return new Iso4217Model(
                        first.CurrencyName,
                        first.Currency,
                        first.CurrencyNumber,
                        first.CurrencyMinorUnits)
                    {
                        Entities = g.Select(e => new Iso4217Entity(e.CountryName))
                                    .OrderBy(cn => cn.Name)
                                    .ToArray()
                    };
                })
                .OrderBy(m => m.Currency?.Value)
                .ToArray();

        /* List One deduplicate */
        var listOneDuplicates =
            listOneModels
                .Select((m, i) => new ModelIndex(m, i))
                .Where(mi =>
                    listOneModels
                        .Select((m, i) => new ModelIndex(m, i))
                        .Any(mi2 => mi2.Model.CurrencyName == mi.Model.CurrencyName && mi.Index != mi2.Index))
                .GroupBy(mi => mi.Model.CurrencyName)
                .ToDictionary(g => g.Key, g => g.ToArray());
        foreach (var kvp in listOneDuplicates)
        {
            var counter = 1;
            foreach (var modelIndex in kvp.Value)
            {
                var currencyName = counter == 1
                    ? modelIndex.Model.CurrencyName
                    : modelIndex.Model.CurrencyName + counter.ToString();
                listOneModels[modelIndex.Index] =
                    listOneModels[modelIndex.Index]
                    with
                    {
                        CurrencyName = currencyName
                    };
                ++counter;
            }
        }

        return new Iso4217Models(dataSet.Published, listOneModels);
    }

    /// <summary>
    /// Generates code for the ISO 4217 standard.
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
        Iso4217Options options,
        ILogger logger,
        CancellationToken cancellationToken = default)
    {
        using var loggerScope = logger.BeginScope("ISO 4217 currency codes");
        logger.LogInformation("Generation started.");

        logger.LogDebug("Preparing models from imported files.");
        var models = await PrepareModelsAsync(options, cancellationToken);

        logger.LogDebug("Generating to project in folder '{ProjectFolder}'.", options.ProjectFolder);
        var projectDirectory = new DirectoryInfo(options.ProjectFolder);

        logger.LogDebug("Generating codes.");
        var iso4217CodeFileName = Path.Combine(projectDirectory.FullName, "Iso4217", "Iso4217Code.cs");
        using var iso4217CodeFile = File.Open(iso4217CodeFileName, FileMode.Create, FileAccess.Write);
        using var iso4217StreamWriter = new StreamWriter(iso4217CodeFile);
        using var iso4217IntentedTextWriter = new IndentedTextWriter(iso4217StreamWriter);

        const string Namespace = "BenBurgers.InternationalStandards.Iso.Iso4217";
        var iso4217CompileUnit = new CodeCompileUnit();
        var iso4217Namespace = new CodeNamespace(Namespace);
        iso4217Namespace.Comments.AddRange(CopyrightNotice.Instance);
        iso4217Namespace.Imports.Add(new CodeNamespaceImport($"{Namespace}.Attributes"));
        iso4217Namespace.Types.Add(Enum(models.Published, models.Models));
        iso4217CompileUnit.Namespaces.Add(iso4217Namespace);

        logger.LogDebug("Writing generated code to file '{iso4217CodeFileName}'.", iso4217CodeFileName);
        var codeProvider = new CSharpCodeProvider();
        codeProvider.GenerateCodeFromCompileUnit(iso4217CompileUnit, iso4217IntentedTextWriter, new CodeGeneratorOptions());
        iso4217IntentedTextWriter.Close();

        logger.LogInformation("Generation completed.");
    }

    private static readonly Regex SanitizeRegex = new(@"[ \-,()'\.’]");
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

    private static CodeTypeDeclaration Enum(DateOnly publishedDate, IEnumerable<Iso4217Model> models)
    {
        var typeDeclaration = new CodeTypeDeclaration("Iso4217Code") { IsEnum = true };
        typeDeclaration.Comments.AddRange(EnumDocumentation(publishedDate));
        typeDeclaration.Members.AddRange(EnumFields(models).ToArray());
        return typeDeclaration;
    }

    private static CodeMemberField EnumFieldDoc(CodeMemberField field, string name, string value)
    {
        field.Comments.Add(new CodeCommentStatement($"\t\t<item><term>{name}</term><description>{value}</description></item>", true));
        return field;
    }

    private static IEnumerable<CodeTypeMember> EnumFields(IEnumerable<Iso4217Model> models)
    {
        foreach (var model in models)
        {
            // Skip models that miss required data.
            if (model.Currency is null || model.CurrencyNumber is null)
                continue;

            // Field
            var member =
                new CodeMemberField
                {
                    Name = NormalizeName(model.CurrencyName),
                    InitExpression = new CodePrimitiveExpression(model.CurrencyNumber)
                };

            // Documentation
            member.Comments.Add(new CodeCommentStatement($"<summary>{model.CurrencyName}</summary>", true));
            member.Comments.Add(new CodeCommentStatement("<remarks>", true));
            member.Comments.Add(new CodeCommentStatement("\t<list type=\"table\">", true));
            EnumFieldDoc(member, "Entity", string.Join(", ", model.Entities));
            EnumFieldDoc(member, "Currency name", model.CurrencyName);
            EnumFieldDoc(member, "Currency code", model.Currency?.ToString() ?? "N/A");
            EnumFieldDoc(member, "Currency minor units", model.CurrencyMinorUnits?.ToString() ?? "N/A");
            member.Comments.Add(new CodeCommentStatement("\t</list>", true));
            member.Comments.Add(new CodeCommentStatement("</remarks>", true));

            // Attributes
            var entities =
                model
                    .Entities
                    .Select(e => new CodeAttributeDeclaration(nameof(Iso4217EntityAttribute), new CodeAttributeArgument(new CodePrimitiveExpression(e.Name))))
                    .ToArray();
            var currency =
                new CodeAttributeDeclaration(
                    nameof(Iso4217CurrencyNameAttribute),
                    new CodeAttributeArgument(new CodePrimitiveExpression(model.CurrencyName)));
            var alpha =
                new CodeAttributeDeclaration(
                    nameof(Iso4217AlphaAttribute),
                    new CodeAttributeArgument(new CodePrimitiveExpression(model.Currency?.ToString()!)));
            var attributes =
                entities
                    .Append(currency)
                    .Append(alpha);
            if (model.CurrencyMinorUnits is { } currencyMinorUnits)
                attributes =
                    attributes.Append(
                        new CodeAttributeDeclaration(
                            nameof(Iso4217MinorUnitsAttribute),
                            new CodeAttributeArgument(new CodePrimitiveExpression(currencyMinorUnits))));
            member
                .CustomAttributes
                .AddRange(attributes.ToArray());

            yield return member;
        }
    }

    private static CodeCommentStatementCollection EnumDocumentation(DateOnly publishedDate) =>
        new(
            new CodeCommentStatement[]
            {
                new("<summary>An <a href=\"https://www.iso.org/iso-4217-currency-codes.html\">ISO 4217</a> Currency Code.</summary>", true),
                new("<remarks>", true),
                new("<para>The <a href=\"https://www.six-group.com/en/products-services/financial-information/data-standards.html\">SIX Financial Information AG</a> is the sole authority of ISO 4217 codes.<br />Only they can designate ISO 4217 codes. This work is a derivation and enhancement and anything other than ISO 639-1 is the responsibility of the respective copyright holders.</para>", true),
                new($"<para>The ISO 4217 codes in this version were published at {publishedDate:D}.</para>", true),
                new("<para>If you notice any mistake in this work, please create a Pull Request or notify the repository owner or a contributor as soon as possible.</para>", true),
                new("<para>Extension methods from <see cref=\"Iso4217CodeExtensions\" /> enable conversion from and to <see cref=\"Iso4217Code\" />.<br />To convert from an Alpha code in a <see cref=\"string\" />, use the extension method <see cref=\"Iso4217CodeExtensions.ToIso4217(string)\" />.</para>", true),
                new("</remarks>", true)
            });
}
