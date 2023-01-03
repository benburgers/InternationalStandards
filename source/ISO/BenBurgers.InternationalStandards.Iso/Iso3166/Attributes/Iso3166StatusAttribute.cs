/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso3166.Attributes;

/// <summary>
/// An attribute for the status of an <see cref="Iso3166Code" />.
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
internal sealed class Iso3166StatusAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166StatusAttribute" />.
    /// </summary>
    /// <param name="status">The status of the annotated <see cref="Iso3166Code" />.</param>
    internal Iso3166StatusAttribute(Iso3166Status status)
    {
        this.Status = status;
    }

    /// <summary>
    /// Gets the status of the annotated <see cref="Iso3166Code" />.
    /// </summary>
    internal Iso3166Status Status { get; }
}
