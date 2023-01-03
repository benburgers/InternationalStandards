/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso4217.Comparers;

/// <summary>
/// Compares <see cref="Iso4217Code" /> based on their currency name and returns the difference.
/// </summary>
public sealed class Iso4217CodeCurrencyNameNullableComparer : IComparer<Iso4217Code?>
{
    /// <inheritdoc />
    public int Compare(Iso4217Code? x, Iso4217Code? y) =>
        (x, y) switch
        {
            (null, null) => 0,
            (null, _) => int.MinValue,
            (_, null) => int.MaxValue,
            ({ } x1, { } y1) => x1.ToModel().CurrencyName.CompareTo(y1.ToModel().CurrencyName)
        };
}
