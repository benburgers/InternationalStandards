/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;
using BenBurgers.Text.Csv.Attributes;

namespace BenBurgers.InternationalStandards.Iso.IO.Iso639;

/// <summary>
/// A record in an ISO 639-3 Code Table.
/// </summary>
/// <param name="Part1">
/// The ISO 639-1 Alpha-2 code.
/// </param>
/// <param name="Part2B">
/// The ISO 639-2B Alpha-3 code.
/// </param>
/// <param name="Part2T">
/// The ISO 639-2T Alpha-3 code.
/// </param>
/// <param name="Part3">
/// The ISO 639-3 Alpha-3 code.
/// </param>
/// <param name="Scope">
/// The scope.
/// </param>
/// <param name="LanguageType">
/// The language type.
/// </param>
/// <param name="RefName">
/// The reference name.
/// </param>
/// <param name="Comment">
/// An optional comment.
/// </param>
public sealed record Iso639Part3CodeTableRecord(
    Alpha2? Part1,
    Alpha3? Part2T,
    Alpha3? Part2B,
    [property: CsvColumn("Id")] Alpha3? Part3,
    Iso639Scope Scope,
    [property: CsvColumn("Language_Type")] Iso639LanguageType LanguageType,
    [property: CsvColumn("Ref_Name")] string RefName,
    string? Comment) : IIso639Part3TableRecord;
