/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso4217.Comparers;

/// <summary>
/// Compares <see cref="Iso4217Code" /> based on their Alpha code and returns the difference.
/// </summary>
public sealed class Iso4217CodeAlphaNullableComparer : IComparer<Iso4217Code?>
{
    /// <inheritdoc />
    public int Compare(Iso4217Code? x, Iso4217Code? y) =>
        (x, y) switch
        {
            (null, null) => 0,
            (null, _) => int.MinValue,
            (_, null) => int.MaxValue,
            ({ } x1, { } y1) => x1.ToAlpha().CompareTo(y1.ToAlpha())
        };
}
