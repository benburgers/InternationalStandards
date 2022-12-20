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
    internal static readonly IReadOnlyDictionary<Iso3166Code, Iso3166Attributes> Attributes =
        typeof(Iso3166Code)
            .GetFields(BindingFlags.Static | BindingFlags.Public)
            .ToDictionary(
                f => (Iso3166Code)f.GetValue(null)!,
                f => new Iso3166Attributes(
                        f.GetCustomAttribute<Iso3166AlphaAttribute>()!,
                        f.GetCustomAttribute<Iso3166IndependentAttribute>()!,
                        f.GetCustomAttribute<Iso3166StatusAttribute>()!,
                        f.GetCustomAttributes<Iso3166FullNameAttribute>().ToHashSet(),
                        f.GetCustomAttributes<Iso3166ShortNameAttribute>().ToHashSet(),
                        f.GetCustomAttributes<Iso3166ShortNameUpperCaseAttribute>().ToHashSet()));

    internal static readonly IReadOnlyDictionary<string, Iso3166Code> AlphaLookup =
        Attributes
            .SelectMany(kvp =>
            new KeyValuePair<string, Iso3166Code>[]
            {
                new(kvp.Value.AlphaAttribute.Alpha2.ToString(), kvp.Key),
                new(kvp.Value.AlphaAttribute.Alpha3.ToString(), kvp.Key)
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
            query = query.Where(kvp => alpha2Codes.Contains(kvp.Value.AlphaAttribute.Alpha2));
        if (filter.Alpha3Codes is { } alpha3Codes)
            query = query.Where(kvp => alpha3Codes.Contains(kvp.Value.AlphaAttribute.Alpha3));
        if (filter.Independent is { } independent)
            query = query.Where(kvp => kvp.Value.IndependentAttribute.Independent == independent);
        if (filter.Status is { } status)
            query = query.Where(kvp => kvp.Value.StatusAttribute.Status == status);
        return query.Select(kvp => kvp.Key);
    }
}
