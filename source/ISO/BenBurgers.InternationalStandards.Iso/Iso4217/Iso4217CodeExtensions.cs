﻿/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217.Exceptions;

namespace BenBurgers.InternationalStandards.Iso.Iso4217;

using static Iso4217Codes;

/// <summary>
/// Extension methods for <see cref="Iso4217" />.
/// </summary>
public static class Iso4217CodeExtensions
{
    /// <summary>
    /// Converts the <paramref name="iso4217Code" /> to its Alpha-3 three-letter code equivalent.
    /// </summary>
    /// <param name="iso4217Code">
    /// The ISO 4217 code.
    /// </param>
    /// <returns>
    /// The Alpha-3 three-letter code equivalent.
    /// </returns>
    public static string ToAlpha(this Iso4217Code iso4217Code)
    {
        return
            Iso4217AttributesLookup[iso4217Code]
                .AlphaAttribute
                .Alpha
                .ToString();
    }

    /// <summary>
    /// Gets the entities that trade the currency.
    /// </summary>
    /// <remarks>
    /// Usually a country, but not exclusively.
    /// </remarks>
    /// <param name="iso4217Code">
    /// The ISO 4217 code.
    /// </param>
    /// <returns>
    /// The entities that trade the currency.
    /// </returns>
    public static IReadOnlyList<string> GetEntities(this Iso4217Code iso4217Code)
    {
        return
            Iso4217AttributesLookup[iso4217Code]
                .EntityAttributes
                .Select(e => e.Entity)
                .ToArray();
    }

    /// <summary>
    /// Gets the reference name of the currency.
    /// </summary>
    /// <param name="iso4217Code">
    /// The ISO 4217 code.
    /// </param>
    /// <returns>
    /// The reference name of the currency.
    /// </returns>
    public static string GetReferenceName(this Iso4217Code iso4217Code)
    {
        return
            Iso4217AttributesLookup[iso4217Code]
                .CurrencyNameAttribute
                .CurrencyName;
    }

    /// <summary>
    /// Gets the number of minor units for the currency.
    /// </summary>
    /// <param name="iso4217Code">
    /// The ISO 4217 code.
    /// </param>
    /// <returns>
    /// The number of minor units for the currency, if applicable.
    /// </returns>
    public static byte? GetMinorUnits(this Iso4217Code iso4217Code)
    {
        return
            Iso4217AttributesLookup[iso4217Code]
                .MinorUnitsAttribute?
                .MinorUnits;
    }

    /// <summary>
    /// Converts an <paramref name="alpha" /> code for ISO 4217 to the generic <see cref="Iso4217Code" />.
    /// </summary>
    /// <param name="alpha">
    /// The Alpha-3 code for ISO 4217.
    /// </param>
    /// <returns>
    /// The corresponding <see cref="Iso4217Code" /> to <paramref name="alpha" />.
    /// </returns>
    /// <exception cref="Iso4217AlphaInvalidException">
    /// An <see cref="Iso4217AlphaInvalidException" /> is thrown if an invalid Alpha code was specified.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// An <see cref="ArgumentNullException" /> is thrown if <paramref name="alpha" /> is <see langword="null" />.
    /// </exception>
    public static Iso4217Code ToIso4217(this string alpha)
    {
        return alpha switch
        {
            { Length: not 3 } => throw new Iso4217AlphaInvalidException(alpha),
            { } when AlphaLookup.TryGetValue(alpha, out Iso4217Code iso4217Code) => iso4217Code,
            { } => throw new Iso4217AlphaInvalidException(alpha),
            // We should never arrive here, since the parameter is not nullable, but in runtime a null value could nevertheless be passed.
            _ => throw new ArgumentNullException(nameof(alpha))
        };
    }
}