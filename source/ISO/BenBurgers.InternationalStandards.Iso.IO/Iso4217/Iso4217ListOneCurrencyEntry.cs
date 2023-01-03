/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Iso4217;

/// <summary>
/// An entry in the ISO 4217 List One currency table.
/// </summary>
/// <param name="CountryName">
/// The name of the country responsible for the currency.
/// </param>
/// <param name="CurrencyName">
/// The name of the currency.
/// </param>
/// <param name="Currency">
/// The three-letter currency code.
/// </param>
/// <param name="CurrencyNumber">
/// The currency number.
/// </param>
/// <param name="CurrencyMinorUnits">
/// The number of minor units in the currency.
/// </param>
public record Iso4217ListOneCurrencyEntry(
    string CountryName,
    string CurrencyName,
    Alpha3? Currency,
    int? CurrencyNumber,
    int? CurrencyMinorUnits);