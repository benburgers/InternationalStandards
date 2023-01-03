/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;
using BenBurgers.InternationalStandards.Iso.Iso4217.Comparers;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso4217.Comparers;

public class Iso4217CodeCurrencyNameNullableComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { null, null, 0 },
            new object?[] { null, Iso4217Code.ArmenianDram, int.MinValue },
            new object?[] { Iso4217Code.AzerbaijanManat, null, int.MaxValue },
            new object?[] { Iso4217Code.Gold, Iso4217Code.Silver, -1 },
            new object?[] { Iso4217Code.Platinum, Iso4217Code.Gold, 1 },
            new object?[] { Iso4217Code.BrazilianReal, Iso4217Code.BrazilianReal, 0 }
        };

    [Theory(DisplayName = "Iso4217CodeCurrencyNameNullableComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(Iso4217Code? x, Iso4217Code? y, int expected)
    {
        // Arrange
        var comparer = new Iso4217CodeCurrencyNameNullableComparer();

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
