/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639.Comparers;

/// <summary>
/// Compares ISO 639 codes based on their numeric code.
/// </summary>
public sealed class Iso639CodeNumericComparer : IComparer<Iso639Code>
{
    /// <inheritdoc />
    public int Compare(Iso639Code x, Iso639Code y) =>
        ((short)x).CompareTo((short)y);
}
