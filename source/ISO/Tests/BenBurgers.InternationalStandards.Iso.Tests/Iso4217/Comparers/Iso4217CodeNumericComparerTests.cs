/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;
using BenBurgers.InternationalStandards.Iso.Iso4217.Comparers;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso4217.Comparers;

public class Iso4217CodeNumericComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { Iso4217Code.Gold, Iso4217Code.Silver, -2 },
            new object?[] { Iso4217Code.Tugrik, Iso4217Code.Rupiah, 136 },
            new object?[] { Iso4217Code.Platinum, Iso4217Code.Platinum, 0 }
        };

    [Theory(DisplayName = "Iso4217CodeNumericComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(Iso4217Code x, Iso4217Code y, int expected)
    {
        // Arrange
        var comparer = new Iso4217CodeNumericComparer();

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
