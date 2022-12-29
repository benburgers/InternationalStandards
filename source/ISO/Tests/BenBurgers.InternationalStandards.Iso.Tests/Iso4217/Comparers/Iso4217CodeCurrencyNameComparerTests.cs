/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;
using BenBurgers.InternationalStandards.Iso.Iso4217.Comparers;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso4217.Comparers;

public class Iso4217CodeCurrencyNameComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { Iso4217Code.TurkishLira, Iso4217Code.Yen, -1 },
            new object?[] { Iso4217Code.TurkmenistanNewManat, Iso4217Code.Rupiah, 1 },
            new object?[] { Iso4217Code.IndianRupee, Iso4217Code.IndianRupee, 0 }
        };

    [Theory(DisplayName = "Iso4217CodeCurrencyNameComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(Iso4217Code x, Iso4217Code y, int expected)
    {
        // Arrange
        var comparer = new Iso4217CodeCurrencyNameComparer();

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
