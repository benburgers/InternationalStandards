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
/// <param name="Independent">
/// A value that indicates whether the ISO 3166 country is considered independent by the ISO 3166 Maintenance Agency.
/// </param>
/// <param name="Status">
/// The status of the ISO 3166 code.
/// </param>
/// <param name="FullName">
/// The full name of the ISO 3166 country.
/// </param>
/// <param name="ShortName">
/// The short name of the ISO 3166 country.
/// </param>
/// <param name="ShortNameUpperCase">
/// The upper case short name of the ISO 3166 country.
/// </param>
public sealed record Iso3166Model(
    short Numeric,
    Alpha2 Alpha2,
    Alpha3 Alpha3,
    bool Independent,
    Iso3166Status Status,
    GlobalizedString FullName,
    GlobalizedString ShortName,
    GlobalizedString ShortNameUpperCase)
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166Model" />.
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
    /// <param name="Independent">
    /// A value that indicates whether the ISO 3166 country is considered independent by the ISO 3166 Maintenance Agency.
    /// </param>
    /// <param name="Status">
    /// The status of the ISO 3166 code.
    /// </param>
    public Iso3166Model(short Numeric, Alpha2 Alpha2, Alpha3 Alpha3, bool Independent, Iso3166Status Status)
        : this(Numeric, Alpha2, Alpha3, Independent, Status, new GlobalizedString(), new GlobalizedString(), new GlobalizedString()) { }
}
