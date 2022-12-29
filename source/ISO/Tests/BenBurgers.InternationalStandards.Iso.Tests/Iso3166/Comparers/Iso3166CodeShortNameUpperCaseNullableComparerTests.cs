/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166.Comparers;
using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso3166.Comparers;

public class Iso3166CodeShortNameUpperCaseNullableComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { Iso639Code.English, null, null, null, 0 },
            new object?[] { Iso639Code.English, null, null, Iso3166Code.Antarctica, int.MinValue },
            new object?[] { Iso639Code.English, null, Iso3166Code.Greenland, null, int.MaxValue },
            new object?[] { Iso639Code.English, null, Iso3166Code.Germany, Iso3166Code.Honduras, -1 },
            new object?[] { Iso639Code.English, null, Iso3166Code.Nepal, Iso3166Code.Ireland, 1 },
            new object?[] { Iso639Code.English, null, Iso3166Code.Italy, Iso3166Code.Italy, 0 }
        };

    [Theory(DisplayName = "Iso3166CodeShortNameUpperCaseNullableComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(
        Iso639Code language,
        Iso639Code? languageDefault,
        Iso3166Code? x,
        Iso3166Code? y,
        int expected)
    {
        // Arrange
        var comparer = new Iso3166CodeShortNameUpperCaseNullableComparer(language, languageDefault);

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
