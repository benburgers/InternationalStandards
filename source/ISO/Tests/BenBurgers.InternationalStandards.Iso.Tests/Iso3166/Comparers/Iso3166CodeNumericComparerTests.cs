/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166.Comparers;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso3166.Comparers;

public class Iso3166CodeNumericComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { Iso3166Code.Greece, Iso3166Code.Belgium, 244 },
            new object?[] { Iso3166Code.Paraguay, Iso3166Code.Uruguay, -258 },
            new object?[] { Iso3166Code.Vanuatu, Iso3166Code.Vanuatu, 0 }
        };

    [Theory(DisplayName = "Iso3166CodeNumericComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(Iso3166Code x, Iso3166Code y, int expected)
    {
        // Arrange
        var comparer = new Iso3166CodeNumericComparer();

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
