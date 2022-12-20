/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso3166.Attributes;

/// <summary>
/// An attribute that indicates whether an ISO 3166 country is considered independent by the ISO 3166 Maintenance Agency.
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
internal sealed class Iso3166IndependentAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166IndependentAttribute" />.
    /// </summary>
    /// <param name="independent">A value that indicates whether an ISO 3166 country is considered independent by the ISO 3166 Maintenance Agency.</param>
    internal Iso3166IndependentAttribute(bool independent)
    {
        this.Independent = independent;
    }

    /// <summary>
    /// Gets a value that indicates whether an ISO 3166 country is considered independent by the ISO 3166 Maintenance Agency.
    /// </summary>
    internal bool Independent { get; }
}