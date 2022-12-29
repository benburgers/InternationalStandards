/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166.Comparers;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso3166.Comparers;

public class Iso3166CodeAlpha2ComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { Iso3166Code.Greece, Iso3166Code.Albania, 1 },
            new object?[] { Iso3166Code.Andorra, Iso3166Code.Guam, -1 },
            new object?[] { Iso3166Code.Guatemala, Iso3166Code.Guatemala, 0 }
        };

    [Theory(DisplayName = "Iso3166CodeAlpha2Comparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(Iso3166Code x, Iso3166Code y, int expected)
    {
        // Arrange
        var comparer = new Iso3166CodeAlpha2Comparer();

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
