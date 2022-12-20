/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166;

namespace BenBurgers.InternationalStandards.Iso.IO.Iso3166.Xml;

/// <summary>
/// An ISO 3166 country from XML.
/// </summary>
/// <param name="Id">The unique identifier of the ISO 3166 country.</param>
/// <param name="Version">The version of the ISO 3166 country.</param>
/// <param name="Alpha2">The Alpha-2 code of the ISO 3166 country.</param>
/// <param name="Alpha3">The Alpha-3 code of the ISO 3166 country.</param>
/// <param name="Numeric">The numeric code of the ISO 3166 country.</param>
/// <param name="Independent">A value that indicates whether the ISO 3166 country is considered independent.</param>
/// <param name="Status">The status of the ISO 3166 country.</param>
/// <param name="FullName">The full name of the ISO 3166 country.</param>
/// <param name="ShortName">The short name of the ISO 3166 country.</param>
/// <param name="ShortNameUpperCase">The upper case short name of the ISO 3166 country.</param>
/// <param name="Languages">The languages that are associated with the ISO 3166 country.</param>
public sealed record Iso3166XmlCountry(
    Alpha2 Id,
    int Version,
    Alpha2 Alpha2,
    Alpha3 Alpha3,
    short Numeric,
    bool Independent,
    Iso3166Status Status,
    Iso3166XmlMultilingualName FullName,
    Iso3166XmlMultilingualName ShortName,
    Iso3166XmlMultilingualName ShortNameUpperCase,
    Iso3166XmlLanguages Languages);