/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;
using BenBurgers.InternationalStandards.Iso.Iso4217.Comparers;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso4217.Comparers;

public class Iso4217CodeNumericNullableComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { null, null, 0 },
            new object?[] { null, Iso4217Code.AustralianDollar, int.MinValue },
            new object?[] { Iso4217Code.HongKongDollar, null, int.MaxValue },
            new object?[] { Iso4217Code.Hryvnia, Iso4217Code.JordanianDinar, 580 },
            new object?[] { Iso4217Code.KenyanShilling, Iso4217Code.Kwanza, -569 },
            new object?[] { Iso4217Code.ChileanPeso, Iso4217Code.ChileanPeso, 0 }
        };

    [Theory(DisplayName = "Iso4217CodeNumericNullableComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(Iso4217Code? x, Iso4217Code? y, int expected)
    {
        // Arrange
        var comparer = new Iso4217CodeNumericNullableComparer();

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
