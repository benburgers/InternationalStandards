/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166.Comparers;
using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso3166.Comparers;

public class Iso3166CodeFullNameComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { Iso639Code.English, null, Iso3166Code.Aruba, Iso3166Code.Czechia, int.MaxValue },
            new object?[] { Iso639Code.English, null, Iso3166Code.Mexico, Iso3166Code.Netherlands, 1 },
            new object?[] { Iso639Code.English, null, Iso3166Code.Nauru, Iso3166Code.Nauru, 0 }
        };

    [Theory(DisplayName = "Iso3166CodeFullNameComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(
        Iso639Code language,
        Iso639Code? languageDefault,
        Iso3166Code x,
        Iso3166Code y,
        int expected)
    {
        // Arrange
        var comparer = new Iso3166CodeFullNameComparer(language, languageDefault);

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
