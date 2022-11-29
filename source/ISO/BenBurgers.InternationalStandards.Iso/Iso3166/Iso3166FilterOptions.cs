/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso3166;

/// <summary>
/// Filter options for querying ISO 3166 codes.
/// </summary>
/// <param name="NumericRange">
/// Only include this range of numeric values.
/// </param>
/// <param name="Alpha2Codes">
/// Only include these Alpha-2 codes.
/// </param>
/// <param name="Alpha3Codes">
/// Only include these Alpha-3 codes.
/// </param>
public sealed record Iso3166FilterOptions(
    Range? NumericRange = null,
    IReadOnlyCollection<Alpha2>? Alpha2Codes = null,
    IReadOnlyCollection<Alpha3>? Alpha3Codes = null);
