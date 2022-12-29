/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;
using BenBurgers.InternationalStandards.Iso.Iso4217.Comparers;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso4217.Comparers;

public class Iso4217CodeAlphaComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { Iso4217Code.Euro, Iso4217Code.USDollar, -1 },
            new object?[] { Iso4217Code.NewZealandDollar, Iso4217Code.BahamianDollar, 1 },
            new object?[] { Iso4217Code.Yen, Iso4217Code.Yen, 0 }
        };

    [Theory(DisplayName = "Iso4217CodeAlphaComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(Iso4217Code x, Iso4217Code y, int expected)
    {
        // Arrange
        var comparer = new Iso4217CodeAlphaComparer();

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
