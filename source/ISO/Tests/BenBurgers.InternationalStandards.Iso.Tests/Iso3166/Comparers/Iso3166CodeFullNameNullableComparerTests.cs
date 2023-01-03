/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166.Comparers;
using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso3166.Comparers;

public class Iso3166CodeFullNameNullableComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { Iso639Code.English, null, null, null, 0 },
            new object?[] { Iso639Code.English, null, null, Iso3166Code.Antarctica, int.MinValue },
            new object?[] { Iso639Code.English, null, Iso3166Code.Nauru, null, int.MaxValue },
            new object?[] { Iso639Code.English, null, Iso3166Code.Angola, Iso3166Code.UnitedStatesOfAmerica, -1 },
            new object?[] { Iso639Code.English, null, Iso3166Code.Zambia, Iso3166Code.Moldova_theRepublicOf, 1 },
            new object?[] { Iso639Code.English, null, Iso3166Code.Belgium, Iso3166Code.Belgium, 0 }
        };

    [Theory(DisplayName = "Iso3166CodeFullNameNullableComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(
        Iso639Code language,
        Iso639Code? languageDefault,
        Iso3166Code? x,
        Iso3166Code? y,
        int expected)
    {
        // Arrange
        var comparer = new Iso3166CodeFullNameNullableComparer(language, languageDefault);

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
