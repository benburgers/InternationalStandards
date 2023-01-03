/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso4217.Comparers;

/// <summary>
/// Compares <see cref="Iso4217Code" /> based on their numeric code and returns the difference.
/// </summary>
public sealed class Iso4217CodeNumericNullableComparer : IComparer<Iso4217Code?>
{
    /// <inheritdoc />
    public int Compare(Iso4217Code? x, Iso4217Code? y) =>
        (x, y) switch
        {
            (null, null) => 0,
            (null, _) => int.MinValue,
            (_, null) => int.MaxValue,
            ({ } x1, { } y1) => ((short)x1).CompareTo((short)y1)
        };
}
