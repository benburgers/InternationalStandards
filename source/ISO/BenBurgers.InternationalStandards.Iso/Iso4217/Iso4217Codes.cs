/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217.Attributes;
using System.Reflection;

namespace BenBurgers.InternationalStandards.Iso.Iso4217;

/// <summary>
/// Methods for querying <see cref="Iso4217Code" />.
/// </summary>
public static class Iso4217Codes
{
    internal record Iso4217Attributes(
        Iso4217EntityAttribute[] EntityAttributes,
        Iso4217CurrencyNameAttribute CurrencyNameAttribute,
        Iso4217AlphaAttribute AlphaAttribute,
        Iso4217MinorUnitsAttribute? MinorUnitsAttribute);

    internal static readonly IReadOnlyDictionary<Iso4217Code, Iso4217Attributes> Iso4217AttributesLookup =
        typeof(Iso4217Code)
            .GetFields(BindingFlags.Static | BindingFlags.Public)
            .ToDictionary(
                f => (Iso4217Code)f.GetValue(null)!,
                f =>
                {
                    var entityAttributes = f.GetCustomAttributes<Iso4217EntityAttribute>().ToArray();
                    var currencyNameAttribute = f.GetCustomAttribute<Iso4217CurrencyNameAttribute>()!;
                    var alphaAttribute = f.GetCustomAttribute<Iso4217AlphaAttribute>()!;
                    var minorUnitsAttribute = f.GetCustomAttribute<Iso4217MinorUnitsAttribute>();
                    return new Iso4217Attributes(
                        entityAttributes,
                        currencyNameAttribute,
                        alphaAttribute,
                        minorUnitsAttribute);
                });

    internal static readonly IReadOnlyDictionary<string, Iso4217Code> AlphaLookup =
        Iso4217AttributesLookup
            .ToDictionary(
                kvp => kvp.Value.AlphaAttribute.Alpha.ToString(),
                kvp => kvp.Key);

    /// <summary>
    /// Returns a selection of <see cref="Iso4217Code" />.
    /// </summary>
    /// <param name="filter">
    /// The filter for the selection.
    /// </param>
    /// <returns>
    /// An enumeration of <see cref="Iso4217Code" /> filtered by <paramref name="filter" />.
    /// </returns>
    public static IEnumerable<Iso4217Code> Query(Iso4217FilterOptions filter)
    {
        var query = Iso4217AttributesLookup.AsEnumerable();
        if (filter.Entity is { } entity)
            query = query.Where(kvp => kvp.Value.EntityAttributes.Any(e => e.Entity.Contains(entity)));
        if (filter.CurrencyName is { } currencyName)
            query = query.Where(kvp => kvp.Value.CurrencyNameAttribute.CurrencyName.Contains(currencyName));
        if (filter.CurrencyCodes is { } currencyCodes)
            query = query.Where(kvp => currencyCodes.Any(cc => kvp.Value.AlphaAttribute.Alpha.Value == cc.Value));
        return query.Select(kvp => kvp.Key);
    }
}
