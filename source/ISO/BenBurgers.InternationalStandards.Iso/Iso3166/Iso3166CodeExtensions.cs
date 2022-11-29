﻿/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using System.Globalization;
using BenBurgers.InternationalStandards.Iso.Iso3166.Exceptions;

namespace BenBurgers.InternationalStandards.Iso.Iso3166;

/// <summary>
/// Extension methods for <see cref="Iso3166Code" />.
/// </summary>
public static class Iso3166CodeExtensions
{
    /// <summary>
    /// Gets the name for the <paramref name="iso3166Code" />.
    /// </summary>
    /// <param name="iso3166Code">
    /// The ISO 3166 code.
    /// </param>
    /// <param name="nameVariant">
    /// The name variant (e.g.: Short, or Long).
    /// </param>
    /// <param name="cultureInfo">
    /// The culture of the name.
    /// </param>
    /// <returns>
    /// The name for the <paramref name="iso3166Code" />.
    /// </returns>
    /// <exception cref="Iso3166NameMissingException">
    /// An exception that is thrown if the name is missing for the <paramref name="iso3166Code" /> and variant <paramref name="nameVariant" />.
    /// </exception>
    /// <remarks>
    /// The localized names are not part of the ISO 3166 standard.
    /// </remarks>
    public static string GetName(
        this Iso3166Code iso3166Code,
        Iso3166NameVariant nameVariant = Iso3166NameVariant.Short,
        CultureInfo? cultureInfo = null)
    {
        return
            Iso3166Names.ResourceManager.GetString($"{iso3166Code}{nameVariant}", cultureInfo)
            ?? throw new Iso3166NameMissingException(iso3166Code, nameVariant, cultureInfo);
    }

    /// <summary>
    /// Converts the <paramref name="iso3166Code" /> to its Alpha-2 two-letter code equivalent.
    /// </summary>
    /// <param name="iso3166Code">
    /// The ISO 3166 code.
    /// </param>
    /// <returns>
    /// The Alpha-2 two-letter code equivalent.
    /// </returns>
    public static string ToAlpha2(this Iso3166Code iso3166Code)
    {
        return Iso3166Codes.Attributes[iso3166Code].Alpha2.ToString();
    }

    /// <summary>
    /// Converts the <paramref name="iso3166Code" /> to its Alpha-3 three-letter code equivalent.
    /// </summary>
    /// <param name="iso3166Code">
    /// The ISO 3166 code.
    /// </param>
    /// <returns>
    /// The Alpha-3 three-letter code equivalent.
    /// </returns>
    public static string ToAlpha3(this Iso3166Code iso3166Code)
    {
        return Iso3166Codes.Attributes[iso3166Code].Alpha3.ToString();
    }

    /// <summary>
    /// Returns a model that contains the data for <paramref name="iso3166Code" />.
    /// </summary>
    /// <param name="iso3166Code">
    /// The ISO 3166 code.
    /// </param>
    /// <returns>
    /// A model that contains the data for <paramref name="iso3166Code" />.
    /// </returns>
    public static Iso3166Model ToModel(this Iso3166Code iso3166Code)
    {
        var attributes = Iso3166Codes.Attributes[iso3166Code];
        var numeric = (short)iso3166Code;
        var alpha2 = attributes.Alpha2;
        var alpha3 = attributes.Alpha3;
        return new Iso3166Model(numeric, alpha2, alpha3);
    }

    /// <summary>
    /// Converts an <paramref name="alpha" /> code for ISO 3166 to the generic <see cref="Iso3166Code" />.
    /// </summary>
    /// <param name="alpha">
    /// The Alpha-2 or Alpha-3 code for ISO 3166.
    /// </param>
    /// <returns>
    /// The corresponding <see cref="Iso3166Code" /> to <paramref name="alpha" />.
    /// </returns>
    /// <exception cref="Iso3166AlphaInvalidException">
    /// An <see cref="Iso3166AlphaInvalidException" /> is thrown if an invalid Alpha code was specified.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// An <see cref="ArgumentNullException" /> is thrown if <paramref name="alpha" /> is <see langword="null" />.
    /// </exception>
    public static Iso3166Code ToIso3166(this string alpha)
    {
        return alpha switch
        {
            // Check length first to save up time from looking in the dictionary if the length is incorrect.
            { Length: < 2 or > 3 } => throw new Iso3166AlphaInvalidException(alpha),
            { } when Iso3166Codes.AlphaLookup.TryGetValue(alpha, out Iso3166Code iso3166Code) => iso3166Code,
            { } => throw new Iso3166AlphaInvalidException(alpha),
            // We should never arrive here, since the parameter is not nullable, but in runtime a null value could nevertheless be passed.
            _ => throw new ArgumentNullException(nameof(alpha))
        };
    }

    /// <summary>
    /// Attempts to convert an <paramref name="alpha" /> code for ISO 3166 to the generic <see cref="Iso3166Code" />.
    /// </summary>
    /// <param name="alpha">
    /// The Alpha-2 or Alpha-3 code for ISO 3166.
    /// </param>
    /// <param name="iso3166Code">
    /// The ISO 3166 code that was evaluated, or <see langword="null" /> if failed.
    /// </param>
    /// <returns>
    /// A <see cref="bool" /> that indicates whether the <see cref="Iso3166Code" /> was successfully converted.
    /// </returns>
    public static bool TryToIso3166(this string alpha, out Iso3166Code? iso3166Code)
    {
        if (alpha is not { Length: >= 2 or <= 3 }
            || !Iso3166Codes.AlphaLookup.TryGetValue(alpha, out Iso3166Code iso3166CodeLookup))
        {
            iso3166Code = null;
            return false;
        }

        iso3166Code = iso3166CodeLookup;
        return true;
    }
}