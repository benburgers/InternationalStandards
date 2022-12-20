/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639.Comparers;

/// <summary>
/// Compares ISO 639 codes based on their numeric code.
/// </summary>
public sealed class Iso639CodeNumericNullableComparer : IComparer<Iso639Code?>
{
    /// <inheritdoc />
    public int Compare(Iso639Code? x, Iso639Code? y) =>
        (x, y) switch
        {
            (null, null) => 0,
            (null, _) => 1,
            (_, null) => -1,
            ({ } xn, { } yn) => xn.CompareTo(yn)
        };
}
