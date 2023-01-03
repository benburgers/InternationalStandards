/*
 * © 2022-2023 Ben Burgers and contributors.
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
/// <param name="Status">
/// Only include ISO 3166 codes with a particular status.
/// </param>
/// <param name="Independent">
/// Only include ISO 3166 countries that are considered independent by the ISO 3166 Maintenance Agency (if not <see langword="null" /> and <see langword="true" />).
/// If not <see langword="null" /> and <see langword="false" />, then only non-independent ISO 3166 countries are considered.
/// </param>
public sealed record Iso3166FilterOptions(
    Range? NumericRange = null,
    IReadOnlyCollection<Alpha2>? Alpha2Codes = null,
    IReadOnlyCollection<Alpha3>? Alpha3Codes = null,
    Iso3166Status? Status = null,
    bool? Independent = null);
