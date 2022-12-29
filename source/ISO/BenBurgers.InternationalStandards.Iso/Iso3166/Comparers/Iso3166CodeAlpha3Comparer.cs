/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso3166.Comparers;

/// <summary>
/// Compares <see cref="Iso3166Code" /> based on their Alpha-3 code and returns the difference.
/// </summary>
public sealed class Iso3166CodeAlpha3Comparer : IComparer<Iso3166Code>
{
    /// <inheritdoc />
    public int Compare(Iso3166Code x, Iso3166Code y) =>
        x.ToAlpha3().CompareTo(y.ToAlpha3());
}
