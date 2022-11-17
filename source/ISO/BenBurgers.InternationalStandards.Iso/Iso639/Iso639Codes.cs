/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639.Attributes;
using System.Reflection;

namespace BenBurgers.InternationalStandards.Iso.Iso639;

/// <summary>
/// Methods for querying <see cref="Iso639Code" />.
/// </summary>
public static class Iso639Codes
{
    internal record Iso639Attributes(
        Iso639Part1Attribute[] Iso639Part1Attributes,
        Iso639Part2Attribute[] Iso639Part2Attributes,
        Iso639Part3Attribute[] Iso639Part3Attributes,
        Iso639ScopeAttribute ScopeAttribute,
        Iso639LanguageTypeAttribute LanguageTypeAttribute,
        ObsoleteAttribute? ObsoleteAttribute);

    internal static readonly IReadOnlyDictionary<Iso639Code, Iso639Attributes> Iso639AttributesLookup =
        typeof(Iso639Code)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .ToDictionary(
                f => (Iso639Code)f.GetValue(null)!,
                f =>
                {
                    var iso639_1 = f.GetCustomAttributes<Iso639Part1Attribute>().ToArray();
                    var iso639_2 = f.GetCustomAttributes<Iso639Part2Attribute>().ToArray();
                    var iso639_3 = f.GetCustomAttributes<Iso639Part3Attribute>().ToArray();
                    var scope = f.GetCustomAttribute<Iso639ScopeAttribute>()!;
                    var languageType = f.GetCustomAttribute<Iso639LanguageTypeAttribute>()!;
                    var obsolete = f.GetCustomAttribute<ObsoleteAttribute>();
                    return new Iso639Attributes(iso639_1, iso639_2, iso639_3, scope, languageType, obsolete);
                });

    internal static readonly IReadOnlyDictionary<string, Iso639Code> Iso639AlphaLookup =
        Iso639AttributesLookup
            .SelectMany(kvp =>
            {
                var records = new Dictionary<string, Iso639Code>();
                if (kvp.Value.Iso639Part1Attributes.Any())
                    records[kvp.Value.Iso639Part1Attributes.First().Iso639Part1.ToString()] = kvp.Key;
                if (kvp.Value.Iso639Part2Attributes.Any())
                {
                    var part2Attribute = kvp.Value.Iso639Part2Attributes.First();
                    records[part2Attribute.Iso639Part2T.ToString()] = kvp.Key;
                }
                if (kvp.Value.Iso639Part3Attributes.Any())
                    records[kvp.Value.Iso639Part3Attributes.First().Iso639Part3.ToString()] = kvp.Key;
                return records;
            })
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

    /// <summary>
    /// Returns a selection of <see cref="Iso639Code" />.
    /// </summary>
    /// <param name="filter">
    /// The filter for the selection.
    /// </param>
    /// <returns>
    /// An enumeration of <see cref="Iso639Code" /> filtered by <paramref name="filter" />.
    /// </returns>
    public static IEnumerable<Iso639Code> Query(Iso639FilterOptions filter)
    {
        bool CheckDeprecated(Iso639AttributeBase attribute)
        {
            return filter.IncludeDeprecated || !attribute.Deprecated;
        }

        var query = Iso639AttributesLookup.AsEnumerable();
        if (filter.MustHavePart1)
            query = query.Where(kvp => kvp.Value.Iso639Part1Attributes.Any(CheckDeprecated));
        if (filter.MustHavePart2)
            query = query.Where(kvp => kvp.Value.Iso639Part2Attributes.Any(CheckDeprecated));
        if (filter.MustHavePart3)
            query = query.Where(kvp => kvp.Value.Iso639Part3Attributes.Any(CheckDeprecated));
        if ((int)filter.Scope > 0)
            query = query.Where(kvp => (kvp.Value.ScopeAttribute.Scope & filter.Scope) > 0);
        if ((int)filter.LanguageType > 0)
            query = query.Where(kvp => (kvp.Value.LanguageTypeAttribute.LanguageType & filter.LanguageType) > 0);
        if (!filter.IncludeDeprecated)
            query = query.Where(kvp => kvp.Value.ObsoleteAttribute is null);
        return query.Select(kvp => kvp.Key);
    }
}
