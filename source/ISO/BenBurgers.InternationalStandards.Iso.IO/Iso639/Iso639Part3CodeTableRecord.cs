/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;

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
public record Iso639Part3CodeTableRecord(
    [property: Iso639TableColumn("Part1")]
    Alpha2? Part1,

    [property: Iso639TableColumn("Part2T")]
    Alpha3? Part2T,

    [property: Iso639TableColumn("Part2B")]
    Alpha3? Part2B,

    [property: Iso639TableColumn("Id")]
    Alpha3? Part3,

    [property: Iso639TableColumn("Scope")]
    Iso639Scope Scope,

    [property: Iso639TableColumn("Language_Type")]
    Iso639LanguageType LanguageType,

    [property: Iso639TableColumn("Ref_Name")]
    string RefName,

    [property: Iso639TableColumn("Comment")]
    string? Comment);
