/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166.Comparers;
using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso3166.Comparers;

public class Iso3166CodeShortNameNullableComparerTests
{
    public static IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { Iso639Code.English, null, null, null, 0 },
            new object?[] { Iso639Code.English, null, null, Iso3166Code.AmericanSamoa, int.MinValue },
            new object?[] { Iso639Code.English, null, Iso3166Code.Samoa, null, int.MaxValue },
            new object?[] { Iso639Code.English, null, Iso3166Code.SaintLucia, Iso3166Code.Zambia, -1 },
            new object?[] { Iso639Code.English, null, Iso3166Code.Zimbabwe, Iso3166Code.VietNam, 1 },
            new object?[] { Iso639Code.English, null, Iso3166Code.Vanuatu, Iso3166Code.Vanuatu, 0 }
        };

    [Theory(DisplayName = "Iso3166CodeShortNameNullableComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(
        Iso639Code language,
        Iso639Code? languageDefault,
        Iso3166Code? x,
        Iso3166Code? y,
        int expected)
    {
        // Arrange
        var comparer = new Iso3166CodeShortNameNullableComparer(language, languageDefault);

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
