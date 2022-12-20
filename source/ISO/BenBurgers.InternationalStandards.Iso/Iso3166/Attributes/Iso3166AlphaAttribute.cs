/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso3166.Attributes;

/// <summary>
/// An attribute for the alpha codes of <see cref="Iso3166Code" />.
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
internal sealed class Iso3166AlphaAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166AlphaAttribute" />.
    /// </summary>
    /// <param name="alpha2">
    /// The Alpha-2 code for the ISO 3166 country.
    /// </param>
    /// <param name="alpha3">
    /// The Alpha-3 code for the ISO 3166 country.
    /// </param>
    internal Iso3166AlphaAttribute(string alpha2, string alpha3)
    {
        Alpha2 = new Alpha2(alpha2);
        Alpha3 = new Alpha3(alpha3);
    }

    /// <summary>
    /// Gets the Alpha-2 code for the ISO 3166 country.
    /// </summary>
    internal Alpha2 Alpha2 { get; }

    /// <summary>
    /// Gets the Alpha-3 code for the ISO 3166 country.
    /// </summary>
    internal Alpha3 Alpha3 { get; }
}
