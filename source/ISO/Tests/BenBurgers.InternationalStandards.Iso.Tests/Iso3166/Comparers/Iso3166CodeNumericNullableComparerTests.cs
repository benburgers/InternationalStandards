/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166.Comparers;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso3166.Comparers;

public class Iso3166CodeNumericNullableComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { null, null, 0 },
            new object?[] { null, Iso3166Code.Albania, int.MinValue },
            new object?[] { Iso3166Code.Portugal, null, int.MaxValue },
            new object?[] { Iso3166Code.Poland, Iso3166Code.Philippines, 8 },
            new object?[] { Iso3166Code.PuertoRico, Iso3166Code.Romania, -12 },
            new object?[] { Iso3166Code.UnitedKingdomOfGreatBritainAndNorthernIreland, Iso3166Code.UnitedKingdomOfGreatBritainAndNorthernIreland, 0 }
        };

    [Theory(DisplayName = "Iso3166CodeNumericNullableComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(Iso3166Code? x, Iso3166Code? y, int expected)
    {
        // Arrange
        var comparer = new Iso3166CodeNumericNullableComparer();

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
