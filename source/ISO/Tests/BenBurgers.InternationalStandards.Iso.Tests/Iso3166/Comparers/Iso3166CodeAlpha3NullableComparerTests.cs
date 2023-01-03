/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166.Comparers;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso3166.Comparers;

public class Iso3166CodeAlpha3NullableComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { null, null, 0 },
            new object?[] { null, Iso3166Code.Andorra, int.MinValue },
            new object?[] { Iso3166Code.Belize, null, int.MaxValue },
            new object?[] { Iso3166Code.Bolivia_PlurinationalStateOf, Iso3166Code.Bhutan, -1 },
            new object?[] { Iso3166Code.SanMarino, Iso3166Code.Benin, 1 },
            new object?[] { Iso3166Code.Taiwan, Iso3166Code.Taiwan, 0 }
        };


    [Theory(DisplayName = "Iso3166CodeAlpha3NullableComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(Iso3166Code? x, Iso3166Code? y, int expected)
    {
        // Arrange
        var comparer = new Iso3166CodeAlpha3NullableComparer();

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
