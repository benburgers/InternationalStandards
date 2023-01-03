/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639.Comparers;

/// <summary>
/// Compares ISO 639 codes by their Part 1 codes.
/// </summary>
public sealed class Iso639CodeAlphaPart1NullableComparer : IComparer<Iso639Code?>
{
    /// <inheritdoc />
    public int Compare(Iso639Code? x, Iso639Code? y) =>
        (x?.HasPart1() == true ? x?.ToPart1() : null, y?.HasPart1() == true ? y?.ToPart1() : null) switch
        {
            (null, null) => 0,
            (null, _) => int.MinValue,
            (_, null) => int.MaxValue,
            ({ } x1, { } y1) => x1.CompareTo(y1)
        };
}