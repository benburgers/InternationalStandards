/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;
using BenBurgers.InternationalStandards.Iso.Iso4217.Comparers;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso4217.Comparers;

public class Iso4217CodeAlphaNullableComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { null, null, 0 },
            new object?[] { null, Iso4217Code.ArgentinePeso, int.MinValue },
            new object?[] { Iso4217Code.ArubanFlorin, null, int.MaxValue },
            new object?[] { Iso4217Code.BahamianDollar, Iso4217Code.Dobra, -1 },
            new object?[] { Iso4217Code.Yen, Iso4217Code.YuanRenminbi, 1 },
            new object?[] { Iso4217Code.Euro, Iso4217Code.Euro, 0 }
        };

    [Theory(DisplayName = "Iso4217CodeAlphaNullableComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(Iso4217Code? x, Iso4217Code? y, int expected)
    {
        // Arrange
        var comparer = new Iso4217CodeAlphaNullableComparer();

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
