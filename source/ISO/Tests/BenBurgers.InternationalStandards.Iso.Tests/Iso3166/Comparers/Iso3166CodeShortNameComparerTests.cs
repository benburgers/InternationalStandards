/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166.Comparers;
using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso3166.Comparers;

public class Iso3166CodeShortNameComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { Iso639Code.English, null, Iso3166Code.Albania, Iso3166Code.Antarctica, -1 },
            new object?[] { Iso639Code.English, null, Iso3166Code.France, Iso3166Code.Albania, 1 },
            new object?[] { Iso639Code.English, null, Iso3166Code.Bahamas, Iso3166Code.Bahamas, 0 }
        };

    [Theory(DisplayName = "Iso3166CodeShortNameComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(
        Iso639Code language,
        Iso639Code? languageDefault,
        Iso3166Code x,
        Iso3166Code y,
        int expected)
    {
        // Arrange
        var comparer = new Iso3166CodeShortNameComparer(language, languageDefault);

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
