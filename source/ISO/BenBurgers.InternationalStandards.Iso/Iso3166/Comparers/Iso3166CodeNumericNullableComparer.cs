/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso3166.Comparers;

/// <summary>
/// Compares <see cref="Iso3166Code" /> based on their numeric code and returns the difference.
/// </summary>
public sealed class Iso3166CodeNumericNullableComparer : IComparer<Iso3166Code?>
{
    /// <inheritdoc />
    public int Compare(Iso3166Code? x, Iso3166Code? y) =>
        (x, y) switch
        {
            (null, null) => 0,
            (null, _) => int.MinValue,
            (_, null) => int.MaxValue,
            ({ } x1, { } y1) => ((short)x1).CompareTo((short)y1)
        };
}
