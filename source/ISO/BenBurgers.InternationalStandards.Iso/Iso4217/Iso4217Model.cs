/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso4217;

/// <summary>
/// A model for an ISO 4217 record.
/// </summary>
/// <param name="Entities">
/// The currency's entities.
/// </param>
/// <param name="CurrencyName">
/// The currency name.
/// </param>
/// <param name="Currency">
/// The currency code.
/// </param>
/// <param name="CurrencyNumber">
/// The number of the currency.
/// </param>
/// <param name="CurrencyMinorUnits">
/// The number of minor units in the currency.
/// </param>
public record Iso4217Model(
    string[] Entities,
    string CurrencyName,
    Alpha3? Currency,
    int? CurrencyNumber,
    int? CurrencyMinorUnits);