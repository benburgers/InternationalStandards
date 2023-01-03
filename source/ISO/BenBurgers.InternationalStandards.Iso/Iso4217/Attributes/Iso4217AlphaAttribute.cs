/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso4217.Attributes;

/// <summary>
/// An attribute that specifies an ISO 4217 currency's Alpha-3 three-letter code.
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
internal sealed class Iso4217AlphaAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217AlphaAttribute" />.
    /// </summary>
    /// <param name="alpha">
    /// The Alpha-3 three-letter code for an ISO 4217 code.
    /// </param>
    internal Iso4217AlphaAttribute(string alpha)
    {
        this.Alpha = new Alpha3(alpha);
    }

    /// <summary>
    /// Gets the Alpha-3 three-letter code for an ISO 4217 code.
    /// </summary>
    internal Alpha3 Alpha { get; }
}
