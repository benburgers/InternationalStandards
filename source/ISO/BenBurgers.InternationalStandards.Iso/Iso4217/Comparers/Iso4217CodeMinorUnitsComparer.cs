﻿/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso4217.Comparers;

/// <summary>
/// Compares <see cref="Iso4217Code" /> based on their minor units and returns the difference.
/// </summary>
public sealed class Iso4217CodeMinorUnitsComparer : IComparer<Iso4217Code>
{
    /// <inheritdoc />
    public int Compare(Iso4217Code x, Iso4217Code y) =>
        x.ToModel().CurrencyMinorUnits?.CompareTo(y.ToModel().CurrencyMinorUnits) ?? int.MaxValue;
}