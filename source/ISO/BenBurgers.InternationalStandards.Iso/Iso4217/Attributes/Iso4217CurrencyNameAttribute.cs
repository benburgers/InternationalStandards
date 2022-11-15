/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso4217.Attributes;

/// <summary>
/// An attribute that specifies the reference name of an ISO 4217 currency.
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
internal sealed class Iso4217CurrencyNameAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217CurrencyNameAttribute" />.
    /// </summary>
    /// <param name="currencyName">
    /// The reference name of the currency.
    /// </param>
    internal Iso4217CurrencyNameAttribute(string currencyName)
    {
        this.CurrencyName = currencyName;
    }

    /// <summary>
    /// Gets the reference name of the currency.
    /// </summary>
    internal string CurrencyName { get; }
}
