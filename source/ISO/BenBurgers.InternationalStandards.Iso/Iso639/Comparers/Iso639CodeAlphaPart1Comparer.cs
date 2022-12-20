/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639.Comparers;

/// <summary>
/// Compares ISO 639 codes by their Part 1 codes.
/// </summary>
public sealed class Iso639CodeAlphaPart1Comparer : IComparer<Iso639Code>
{
    /// <inheritdoc />
    public int Compare(Iso639Code x, Iso639Code y) =>
        (x.HasPart1() ? x.ToPart1() : null, y.HasPart1() ? y.ToPart1() : null) switch
        {
            (null, null) => 0,
            (null, _) => 1,
            (_, null) => -1,
            ({ } p1, { } p2) => p1.CompareTo(p2)
        };
}
