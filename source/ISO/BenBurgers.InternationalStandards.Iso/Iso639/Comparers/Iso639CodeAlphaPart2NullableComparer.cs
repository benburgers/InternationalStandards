﻿/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639.Comparers;

/// <summary>
/// Compares ISO 639 codes by their Part 2 codes.
/// </summary>
public sealed class Iso639CodeAlphaPart2NullableComparer : IComparer<Iso639Code?>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639CodeAlphaPart2NullableComparer" />.
    /// </summary>
    /// <param name="part2Type">The Part 2 type to compare to.</param>
    public Iso639CodeAlphaPart2NullableComparer(Iso639Part2Type part2Type)
    {
        this.Part2Type = part2Type;
    }

    /// <summary>
    /// Gets the Part 2 type to compare to.
    /// </summary>
    public Iso639Part2Type Part2Type { get; }

    /// <inheritdoc />
    public int Compare(Iso639Code? x, Iso639Code? y) =>
        (x?.HasPart2() == true
            ? x?.ToPart2(this.Part2Type)
            : null,
        y?.HasPart2() == true
            ? y?.ToPart2(this.Part2Type)
            : null) switch
        {
            (null, null) => 0,
            (null, _) => int.MinValue,
            (_, null) => int.MaxValue,
            ({ } x2, { } y2) => x2.CompareTo(y2)
        };
}