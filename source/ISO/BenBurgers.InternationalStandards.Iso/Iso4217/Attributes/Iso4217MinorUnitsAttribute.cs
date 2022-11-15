/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso4217.Attributes;

/// <summary>
/// An attribute that specifies the minor units for the ISO 4217 currency.
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
internal class Iso4217MinorUnitsAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217MinorUnitsAttribute" />.
    /// </summary>
    /// <param name="minorUnits">
    /// The minor units for the currency.
    /// </param>
    internal Iso4217MinorUnitsAttribute(byte minorUnits)
    {
        this.MinorUnits = minorUnits;
    }

    /// <summary>
    /// Gets the minor units for the currency.
    /// </summary>
    internal byte MinorUnits { get; }
}
