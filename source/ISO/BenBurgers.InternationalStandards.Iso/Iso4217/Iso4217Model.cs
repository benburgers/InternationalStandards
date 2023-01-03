/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso4217;

/// <summary>
/// A model for an ISO 4217 record.
/// </summary>
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
public sealed record Iso4217Model(
    string CurrencyName,
    Alpha3? Currency,
    int? CurrencyNumber,
    int? CurrencyMinorUnits)
{
    /// <summary>
    /// Gets or initializes the ISO 4217 entities that trade the currency.
    /// </summary>
    public IReadOnlyList<Iso4217Entity> Entities { get; init; } = new List<Iso4217Entity>();
};