/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso3166.Comparers;

/// <summary>
/// Compares <see cref="Iso3166Code" /> based on their numeric codes and returns the difference.
/// </summary>
public sealed class Iso3166CodeNumericComparer : IComparer<Iso3166Code>
{
    /// <inheritdoc />
    public int Compare(Iso3166Code x, Iso3166Code y) =>
        ((short)x).CompareTo((short)y);
}
