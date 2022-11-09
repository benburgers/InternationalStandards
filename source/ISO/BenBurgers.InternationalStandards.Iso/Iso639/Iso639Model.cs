/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639;

/// <summary>
/// A model for an ISO 639 record.
/// </summary>
/// <param name="Part1">
/// The ISO 639-1 Alpha-2 code.
/// </param>
/// <param name="Part2T">
/// The ISO 639-2T Alpha-3 code.
/// </param>
/// <param name="Part2B">
/// The ISO 639-2B Alpha-3 code.
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
/// <param name="PrintName">
/// The print name.
/// </param>
/// <param name="InvertedName">
/// The inverted name.
/// </param>
public record Iso639Model(
    Alpha2? Part1,
    Alpha3? Part2T,
    Alpha3? Part2B,
    Alpha3? Part3,
    Iso639Scope Scope,
    Iso639LanguageType LanguageType,
    string? RefName,
    string? PrintName,
    string? InvertedName);