/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso4217;

/// <summary>
/// Filter options for querying ISO 4217 codes.
/// </summary>
/// <param name="Entity">
/// One or more entities trade the currency.
/// </param>
/// <param name="CurrencyName">
/// The currency name contains this string.
/// </param>
/// <param name="CurrencyCodes">
/// Include currencies with these codes.
/// </param>
public record Iso4217FilterOptions(
    string? Entity = null,
    string? CurrencyName = null,
    IReadOnlyCollection<Alpha3>? CurrencyCodes = null);