/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166.Comparers;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso3166.Comparers;

public class Iso3166CodeAlpha2NullableComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { null, null, 0 },
            new object?[] { null, Iso3166Code.Anguilla, int.MinValue },
            new object?[] { Iso3166Code.AntiguaAndBarbuda, null, int.MaxValue },
            new object?[] { Iso3166Code.Argentina, Iso3166Code.Australia, -1 },
            new object?[] { Iso3166Code.India, Iso3166Code.Bangladesh, 1 },
            new object?[] { Iso3166Code.Samoa, Iso3166Code.Samoa, 0 }
        };

    [Theory(DisplayName = "Iso3166CodeAlpha2NullableComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(Iso3166Code? x, Iso3166Code? y, int expected)
    {
        // Arrange
        var comparer = new Iso3166CodeAlpha2NullableComparer();

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
