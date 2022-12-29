/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;
using BenBurgers.InternationalStandards.Iso.Iso4217.Comparers;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso4217.Comparers;

public class Iso4217CodeMinorUnitsComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { Iso4217Code.UgandaShilling, Iso4217Code.ArgentinePeso, -1 },
            new object?[] { Iso4217Code.Lek, Iso4217Code.LebanesePound, 0 },
            new object?[] { Iso4217Code.UnidadPrevisional, Iso4217Code.NewTaiwanDollar, 1 }
        };

    [Theory(DisplayName = "Iso4217CodeMinorUnitsComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(Iso4217Code x, Iso4217Code y, int expected)
    {
        // Arrange
        var comparer = new Iso4217CodeMinorUnitsComparer();

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
