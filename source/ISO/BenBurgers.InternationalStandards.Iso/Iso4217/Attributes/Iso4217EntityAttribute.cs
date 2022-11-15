/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso4217.Attributes;

/// <summary>
/// An attribute that specifies an entity that trades an ISO 4217 currency.
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
internal sealed class Iso4217EntityAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217EntityAttribute" />.
    /// </summary>
    /// <param name="entity">
    /// The entity that trades the currency.
    /// </param>
    internal Iso4217EntityAttribute(string entity)
    {
        this.Entity = entity;
    }

    /// <summary>
    /// Gets the entity that trades the currency.
    /// </summary>
    internal string Entity { get; }
}
