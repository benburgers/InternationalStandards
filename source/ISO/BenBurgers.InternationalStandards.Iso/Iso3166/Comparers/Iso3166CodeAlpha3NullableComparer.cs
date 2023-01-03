/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso3166.Comparers;

/// <summary>
/// Compares <see cref="Iso3166Code" /> based on their Alpha-3 code and returns the difference.
/// </summary>
public sealed class Iso3166CodeAlpha3NullableComparer : IComparer<Iso3166Code?>
{
    /// <inheritdoc />
    public int Compare(Iso3166Code? x, Iso3166Code? y) =>
        (x, y) switch
        {
            (null, null) => 0,
            (null, _) => int.MinValue,
            (_, null) => int.MaxValue,
            ({ } x1, { } y1) => x1.ToAlpha3().CompareTo(y1.ToAlpha3())
        };
}
