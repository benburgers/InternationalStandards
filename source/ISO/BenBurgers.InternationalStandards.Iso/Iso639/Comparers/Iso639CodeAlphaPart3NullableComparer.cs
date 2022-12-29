/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639.Comparers;

/// <summary>
/// Compares ISO 639 codes by their Part 2 codes.
/// </summary>
public sealed class Iso639CodeAlphaPart3NullableComparer : IComparer<Iso639Code?>
{
    /// <inheritdoc />
    public int Compare(Iso639Code? x, Iso639Code? y) =>
        (x?.ToPart3(), y?.ToPart3()) switch
        {
            (null, null) => 0,
            (null, _) => int.MinValue,
            (_, null) => int.MaxValue,
            ({ } x3, { } y3) => x3.CompareTo(y3)
        };
}
