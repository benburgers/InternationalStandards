/*
 * © 2022-2023 Ben Burgers and contributors.
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
    private static TAttribute? GetAttribute<TAttribute>(
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
                            .FirstOrDefault() // Prefer non-deprecated, but if there is no active code, pick the first one.
                : attributes.FirstOrDefault() ?? throw new Iso639CodeDeprecatedException(code);
        return attribute;
    }

    private static Iso639Part GetPart(Iso639Part2Type part2Type)
    {
        return part2Type switch
        {
            Iso639Part2Type.Terminological => Iso639Part.Part2T,
            Iso639Part2Type.Bibliographic => Iso639Part.Part2B,
#if NET6_0
            _ => Iso639Part.Part2T
#endif
#if NET7_0_OR_GREATER
            _ => throw new System.Diagnostics.UnreachableException()
#endif
        };
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
                .Iso639Part1Attributes
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
                .Iso639Part2Attributes
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
                .Iso639Part3Attributes
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
    public static string? ToPart1(this Iso639Code iso639Code, bool allowDeprecated = false)
    {
        var attributes = Iso639AttributesLookup[iso639Code];

        if (attributes.ObsoleteAttribute is not null && !allowDeprecated)
            throw new Iso639CodeDeprecatedException(iso639Code);
        if (!attributes.Iso639Part1Attributes.Any())
            throw new Iso639PartNotAssignedException(iso639Code, Iso639Part.Part1);

        var attribute =
            attributes
                .Iso639Part1Attributes
                .GetAttribute(iso639Code, allowDeprecated);

        return attribute?.Iso639Part1.ToString();
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
    public static string? ToPart2(
        this Iso639Code iso639Code,
        Iso639Part2Type part2Type,
        bool allowDeprecated = false)
    {
        var attributes = Iso639AttributesLookup[iso639Code];

        if (attributes.ObsoleteAttribute is not null && !allowDeprecated)
            throw new Iso639CodeDeprecatedException(iso639Code);
        if (!attributes.Iso639Part2Attributes.Any())
            throw new Iso639PartNotAssignedException(iso639Code, GetPart(part2Type));

        var attribute =
            attributes
                .Iso639Part2Attributes
                .GetAttribute(iso639Code, allowDeprecated);

        return part2Type switch
        {
            Iso639Part2Type.Terminological => attribute?.Iso639Part2T.ToString(),
            Iso639Part2Type.Bibliographic => attribute?.Iso639Part2B.ToString(),
#if NET6_0
            _ => attribute?.Iso639Part2T.ToString() // preferable
#endif
#if NET7_0_OR_GREATER
            _ => throw new System.Diagnostics.UnreachableException()
#endif
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
    public static string? ToPart3(
        this Iso639Code iso639Code,
        bool allowDeprecated = false)
    {
        var attributes = Iso639AttributesLookup[iso639Code];

        if (attributes.ObsoleteAttribute is not null && !allowDeprecated)
            throw new Iso639CodeDeprecatedException(iso639Code);
        if (!attributes.Iso639Part3Attributes.Any())
            throw new Iso639PartNotAssignedException(iso639Code, Iso639Part.Part3);

        var attribute =
            attributes
                .Iso639Part3Attributes
                .GetAttribute(iso639Code, allowDeprecated);

        return attribute?.Iso639Part3.ToString();
    }

    /// <summary>
    /// Converts the <paramref name="iso639Code" /> to an <see cref="Iso639Model" />.
    /// </summary>
    /// <param name="iso639Code">
    /// 
    /// </param>
    /// <param name="allowDeprecated"></param>
    /// <returns></returns>
    /// <exception cref="Iso639CodeDeprecatedException"></exception>
    public static Iso639Model ToModel(
        this Iso639Code iso639Code,
        bool allowDeprecated = false)
    {
        var attributes = Iso639AttributesLookup[iso639Code];

        if (attributes.ObsoleteAttribute is not null && !allowDeprecated)
            throw new Iso639CodeDeprecatedException(iso639Code);

        // TODO filter out deprecated codes rather than throwing an exception
        var part1Attribute =
            attributes
                .Iso639Part1Attributes
                .GetAttribute(iso639Code, true);
        var part2Attribute =
            attributes
                .Iso639Part2Attributes
                .GetAttribute(iso639Code, true);
        var part3Attribute =
            attributes
                .Iso639Part3Attributes
                .GetAttribute(iso639Code, true);

        return new Iso639Model(
            part1Attribute?.Iso639Part1,
            part2Attribute?.Iso639Part2T,
            part2Attribute?.Iso639Part2B,
            part3Attribute?.Iso639Part3,
            attributes.ScopeAttribute.Scope,
            attributes.LanguageTypeAttribute.LanguageType,
            "",
            "",
            "");
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

    /// <summary>
    /// Attempts to conver an <paramref name="alpha" /> code for ISO 639 to the generic <see cref="Iso639Code" />.
    /// </summary>
    /// <param name="alpha">
    /// The Alpha-2 or Alpha-3 code for ISO 639.
    /// </param>
    /// <param name="iso639Code">
    /// The ISO 639 code that was evaluated, or <see langword="null" /> if invalid.
    /// </param>
    /// <param name="allowDeprecated">
    /// A <see cref="bool" /> that indicates whether deprecated codes should be considered valid.
    /// </param>
    /// <returns>
    /// A <see cref="bool" /> that indicates whether the <see cref="Iso639Code" /> was successfully converted.
    /// </returns>
    public static bool TryToIso639(
        this string alpha,
        out Iso639Code? iso639Code,
        bool allowDeprecated = false)
    {
        if (alpha.Length is < 2 or > 3)
        {
            iso639Code = null;
            return false;
        }

        if (!Iso639AlphaLookup.TryGetValue(alpha, out var iso639CodeLookup))
        {
            iso639Code = null;
            return false;
        }

        if (!allowDeprecated && Iso639AttributesLookup[iso639CodeLookup].ObsoleteAttribute is not null)
        {
            iso639Code = null;
            return false;
        }

        iso639Code = iso639CodeLookup;
        return true;
    }
}