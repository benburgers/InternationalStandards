/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso3166;

/// <summary>
/// A model of ISO 3166 codes.
/// </summary>
/// <param name="Numeric">
/// The numeric code.
/// </param>
/// <param name="Alpha2">
/// The Alpha-2 code.
/// </param>
/// <param name="Alpha3">
/// The Alpha-3 code.
/// </param>
public sealed record Iso3166Model(
    short Numeric,
    Alpha2 Alpha2,
    Alpha3 Alpha3);
