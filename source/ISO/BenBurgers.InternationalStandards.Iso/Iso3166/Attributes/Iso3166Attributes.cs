/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso3166.Attributes;

/// <summary>
/// The attributes on a particular ISO 3166 code.
/// </summary>
/// <param name="AlphaAttribute">The Alpha attribute.</param>
/// <param name="StatusAttribute">The status attribute.</param>
/// <param name="IndependentAttribute">The independent attribute.</param>
/// <param name="FullNameAttributes">The full name attributes.</param>
/// <param name="ShortNameAttributes">The short name attributes.</param>
/// <param name="ShortNameUpperCaseAttributes">The short name upper case attributes.</param>
internal sealed record Iso3166Attributes(
    Iso3166AlphaAttribute AlphaAttribute,
    Iso3166IndependentAttribute IndependentAttribute,
    Iso3166StatusAttribute StatusAttribute,
    IReadOnlySet<Iso3166FullNameAttribute> FullNameAttributes,
    IReadOnlySet<Iso3166ShortNameAttribute> ShortNameAttributes,
    IReadOnlySet<Iso3166ShortNameUpperCaseAttribute> ShortNameUpperCaseAttributes);