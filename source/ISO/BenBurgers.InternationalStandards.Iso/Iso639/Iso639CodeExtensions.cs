/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639.Attributes;
using BenBurgers.InternationalStandards.Iso.Iso639.Exceptions;

namespace BenBurgers.InternationalStandards.Iso.Iso639;

using static Iso639Codes;

/// <summary>
/// Extension methods for <see cref="Iso639Code" />.
/// </summary>
public static class Iso639CodeExtensions
{
    private static TAttribute GetAttribute<TAttribute>(
        this TAttribute[] attributes,
        Iso639Code code,
        bool allowDeprecated = false)
        where TAttribute : Iso639AttributeBase
    {
        var attribute =
            allowDeprecated
                ? attributes.Select(a => (Attribute: a, Order: a.Deprecated ? 1 : 0))
                            .OrderBy(ad => ad.Order)
                            .Select(ad => ad.Attribute)
                            .First() // Prefer non-deprecated, but if there is no active code, pick the first one.
                : attributes.FirstOrDefault() ?? throw new Iso639CodeDeprecatedException(code);
        return attribute;
    }

    /// <summary>
    /// Returns the ISO 639 language type for <paramref name="iso639Code" />.
    /// </summary>
    /// <param name="iso639Code">
    /// The ISO 639 code.
    /// </param>
    /// <returns>
    /// The ISO 639 language type for <paramref name="iso639Code" />.
    /// </returns>
    public static Iso639LanguageType GetLanguageType(this Iso639Code iso639Code)
    {
        return Iso639AttributesLookup[iso639Code].LanguageTypeAttribute!.LanguageType;
    }

    /// <summary>
    /// Determines whether <paramref name="iso639Code" /> has an ISO 639-1 Alpha-2 code.
    /// </summary>
    /// <param name="iso639Code">
    /// The ISO 639 Code.
    /// </param>
    /// <param name="allowDeprecated">
    /// A <see cref="bool" /> that indicates whether to consider deprecated codes, too.
    /// </param>
    /// <returns>
    /// A <see cref="bool" /> that indicates whether <paramref name="iso639Code" /> has an ISO 639-1 Alpha-2 code.
    /// </returns>
    public static bool HasPart1(this Iso639Code iso639Code, bool allowDeprecated = false)
    {
        return
            Iso639AttributesLookup[iso639Code]
                .Iso639_1Attributes
                .Any(attr => allowDeprecated || !attr.Deprecated);
    }

    /// <summary>
    /// Determines whether <paramref name="iso639Code" /> has an ISO 639-2 Alpha-3 code.
    /// </summary>
    /// <param name="iso639Code">
    /// The ISO 639 code.
    /// </param>
    /// <param name="allowDeprecated">
    /// A <see cref="bool" /> that indicates whether to consider deprecated codes, too.
    /// </param>
    /// <returns>
    /// A <see cref="bool" /> that indicates whether <paramref name="iso639Code" /> has an ISO 639-2 Alpha-3 code.
    /// </returns>
    public static bool HasPart2(this Iso639Code iso639Code, bool allowDeprecated = false)
    {
        return
            Iso639AttributesLookup[iso639Code]
                .Iso639_2Attributes
                .Any(attr => allowDeprecated || !attr.Deprecated);
    }

    /// <summary>
    /// Determines whether <paramref name="iso639Code" /> has an ISO 639-3 Alpha-3 code.
    /// </summary>
    /// <param name="iso639Code">
    /// The ISO 639 code.
    /// </param>
    /// <param name="allowDeprecated">
    /// A <see cref="bool" /> that indicates whether to consider deprecated codes, too.
    /// </param>
    /// <returns>
    /// A <see cref="bool" /> that indicates whether <paramref name="iso639Code" /> has an ISO 639-3 Alpha-3 code.
    /// </returns>
    public static bool HasPart3(this Iso639Code iso639Code, bool allowDeprecated = false)
    {
        return
            Iso639AttributesLookup[iso639Code]
                .Iso639_3Attributes
                .Any(attr => allowDeprecated || !attr.Deprecated);
    }

    /// <summary>
    /// Returns the ISO 639-1 Alpha-2 code for <paramref name="iso639Code" />.
    /// </summary>
    /// <param name="iso639Code">
    /// The ISO 639 code.
    /// </param>
    /// <param name="allowDeprecated">
    /// A <see cref="bool" /> value that indicates whether deprecated codes are allowed.
    /// </param>
    /// <returns>
    /// The ISO 639-1 Alpha-2 code.
    /// </returns>
    /// <exception cref="Iso639PartNotAssignedException">
    /// An <see cref="Iso639PartNotAssignedException" /> is thrown if <paramref name="iso639Code" /> does not have a designation for ISO 639-1.
    /// </exception>
    /// <exception cref="Iso639CodeDeprecatedException">
    /// If <paramref name="allowDeprecated" /> is <see langword="false" /> and there is no active code, an <see cref="Iso639CodeDeprecatedException" /> is thrown.
    /// </exception>
    public static string ToPart1(this Iso639Code iso639Code, bool allowDeprecated = false)
    {
        var attributes = Iso639AttributesLookup[iso639Code];

        if (attributes.ObsoleteAttribute is not null && !allowDeprecated)
            throw new Iso639CodeDeprecatedException(iso639Code);
        if (!attributes.Iso639_1Attributes.Any())
            throw new Iso639PartNotAssignedException(iso639Code, Iso639PartType.Part1);

        var attribute =
            attributes
                .Iso639_1Attributes
                .GetAttribute(iso639Code, allowDeprecated);

        return attribute.Iso639Part1.ToString();
    }

    /// <summary>
    /// Returns an ISO 639-2 Alpha-3 code for <paramref name="iso639Code" />.
    /// </summary>
    /// <param name="iso639Code">
    /// The ISO 639 code.
    /// </param>
    /// <param name="part2Type">
    /// The type of the ISO 639-2 Alpha-3 code to return.
    /// </param>
    /// <param name="allowDeprecated">
    /// A <see cref="bool" /> value that indicates whether deprecated codes are allowed.
    /// </param>
    /// <returns>
    /// The ISO 639-2 Alpha-3 code.
    /// </returns>
    /// <exception cref="Iso639PartNotAssignedException">
    /// An <see cref="Iso639PartNotAssignedException" /> is thrown if <paramref name="iso639Code" /> does not have a designation for ISO 639-2T or ISO 639-2B.
    /// </exception>
    /// <exception cref="Iso639CodeDeprecatedException">
    /// If <paramref name="allowDeprecated" /> is <see langword="false" /> and there is no active code, an <see cref="Iso639CodeDeprecatedException" /> is thrown.
    /// </exception>
    public static string ToPart2(
        this Iso639Code iso639Code,
        Iso639Part2Type part2Type,
        bool allowDeprecated = false)
    {
        var attributes = Iso639AttributesLookup[iso639Code];

        if (attributes.ObsoleteAttribute is not null && !allowDeprecated)
            throw new Iso639CodeDeprecatedException(iso639Code);
        if (!attributes.Iso639_2Attributes.Any())
            throw new Iso639PartNotAssignedException(iso639Code, Iso639PartType.Part2);

        var attribute =
            attributes
                .Iso639_2Attributes
                .GetAttribute(iso639Code, allowDeprecated);

        return part2Type switch
        {
            Iso639Part2Type.Terminological => attribute.Iso639Part2T.ToString(),
            Iso639Part2Type.Bibliographic => attribute.Iso639Part2B.ToString(),
            _ => attribute.Iso639Part2T.ToString() // preferred
        };
    }

    /// <summary>
    /// Returns an ISO 639-3 Alpha-3 code for <paramref name="iso639Code" />.
    /// </summary>
    /// <param name="iso639Code">
    /// The ISO 639 code.
    /// </param>
    /// <param name="allowDeprecated">
    /// A <see cref="bool" /> value that indicates whether deprecated codes are allowed.
    /// </param>
    /// <returns>
    /// The ISO 639-3 Alpha-3 code for <paramref name="iso639Code" />.
    /// </returns>
    /// <exception cref="Iso639PartNotAssignedException">
    /// An <see cref="Iso639PartNotAssignedException" /> is thrown if <paramref name="iso639Code" /> does not have a designation for ISO 639-3.
    /// </exception>
    /// <exception cref="Iso639CodeDeprecatedException">
    /// If <paramref name="allowDeprecated" /> is <see langword="false" /> and there is no active code, an <see cref="Iso639CodeDeprecatedException" /> is thrown.
    /// </exception>
    public static string ToPart3(
        this Iso639Code iso639Code,
        bool allowDeprecated = false)
    {
        var attributes = Iso639AttributesLookup[iso639Code];

        if (attributes.ObsoleteAttribute is not null && !allowDeprecated)
            throw new Iso639CodeDeprecatedException(iso639Code);
        if (!attributes.Iso639_3Attributes.Any())
            throw new Iso639PartNotAssignedException(iso639Code, Iso639PartType.Part3);

        var attribute =
            attributes
                .Iso639_3Attributes
                .GetAttribute(iso639Code, allowDeprecated);

        return attribute.Iso639Part3.ToString();
    }

    /// <summary>
    /// Converts an Alpha-2 or Alpha-3 code to an <see cref="Iso639Code" />.
    /// </summary>
    /// <param name="alpha">
    /// The Alpha-2 or Alpha-3 code.
    /// </param>
    /// <param name="allowDeprecated">
    /// A <see cref="bool" /> value that indicates whether deprecated codes are allowed.
    /// </param>
    /// <returns>
    /// The <see cref="Iso639Code" />.
    /// </returns>
    /// <exception cref="Iso639AlphaInvalidException">
    /// An <see cref="Iso639AlphaInvalidException" /> is thrown if an invalid <paramref name="alpha" /> was specified.
    /// </exception>
    /// <exception cref="Iso639CodeDeprecatedException">
    /// An <see cref="Iso639CodeDeprecatedException" /> is thrown if deprecated codes are not allowed and the current code is deprecated.
    /// </exception>
    public static Iso639Code ToIso639(
        this string alpha,
        bool allowDeprecated = false)
    {
        if (alpha.Length is < 2 or > 3)
            throw new Iso639AlphaInvalidException(alpha);

        if (Iso639AlphaLookup.TryGetValue(alpha, out var iso639Code))
        {
            if (!allowDeprecated && Iso639AttributesLookup[iso639Code].ObsoleteAttribute is not null)
                throw new Iso639CodeDeprecatedException(iso639Code);
            return iso639Code;
        }

        throw new Iso639AlphaInvalidException(alpha);
    }
}