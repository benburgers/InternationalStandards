/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso3166;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
internal sealed class Iso3166Attribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166Attribute" />.
    /// </summary>
    /// <param name="alpha2">
    /// The Alpha-2 code for the ISO 3166 country.
    /// </param>
    /// <param name="alpha3">
    /// The Alpha-3 code for the ISO 3166 country.
    /// </param>
    internal Iso3166Attribute(string alpha2, string alpha3)
    {
        this.Alpha2 = alpha2;
        this.Alpha3 = alpha3;
    }

    /// <summary>
    /// Gets the Alpha-2 code for the ISO 3166 country.
    /// </summary>
    internal string Alpha2 { get; }

    /// <summary>
    /// Gets the Alpha-3 code for the ISO 3166 country.
    /// </summary>
    internal string Alpha3 { get; }
}
