/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166.Attributes;
using System.Reflection;

namespace BenBurgers.InternationalStandards.Iso.Iso3166;

/// <summary>
/// Methods for querying <see cref="Iso3166Code" />.
/// </summary>
public static class Iso3166Codes
{
    internal static readonly IReadOnlyDictionary<Iso3166Code, Iso3166Attribute> Attributes =
        typeof(Iso3166Code)
            .GetFields(BindingFlags.Static | BindingFlags.Public)
            .ToDictionary(f => (Iso3166Code)f.GetValue(null)!, f => f.GetCustomAttribute<Iso3166Attribute>()!);

    internal static readonly IReadOnlyDictionary<string, Iso3166Code> AlphaLookup =
        Attributes
            .SelectMany(kvp =>
            new KeyValuePair<string, Iso3166Code>[]
            {
                new(kvp.Value.Alpha2.ToString(), kvp.Key),
                new(kvp.Value.Alpha3.ToString(), kvp.Key)
            })
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

    /// <summary>
    /// Returns a selection of <see cref="Iso3166Code" />.
    /// </summary>
    /// <param name="filter">
    /// The filter for the selection.
    /// </param>
    /// <returns>
    /// An enumeration of <see cref="Iso3166Code" /> filtered by <paramref name="filter" />.
    /// </returns>
    public static IEnumerable<Iso3166Code> Query(Iso3166FilterOptions filter)
    {
        var query = Attributes.AsEnumerable();
        if (filter.NumericRange is { } numericRange)
            query = query.Where(kvp => numericRange.Start.Value <= (int)kvp.Key && numericRange.End.Value >= (int)kvp.Key);
        if (filter.Alpha2Codes is { } alpha2Codes)
            query = query.Where(kvp => alpha2Codes.Contains(kvp.Value.Alpha2));
        if (filter.Alpha3Codes is { } alpha3Codes)
            query = query.Where(kvp => alpha3Codes.Contains(kvp.Value.Alpha3));
        return query.Select(kvp => kvp.Key);
    }
}
