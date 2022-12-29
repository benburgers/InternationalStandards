/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;
using BenBurgers.InternationalStandards.Iso.Iso4217.Comparers;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso4217.Comparers;

public class Iso4217CodeMinorUnitsNullableComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { null, null, 0 },
            new object?[] { null, Iso4217Code.GibraltarPound, int.MinValue },
            new object?[] { Iso4217Code.Guarani, null, int.MaxValue },
            new object?[] { Iso4217Code.USDollar, Iso4217Code.Euro, 0 },
            new object?[] { Iso4217Code.BrazilianReal, Iso4217Code.UnidadPrevisional, -1 },
            new object?[] { Iso4217Code.ArgentinePeso, Iso4217Code.Gold, 1 }
        };

    [Theory(DisplayName = "Iso4217CodeMinorUnitsNullableComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(Iso4217Code? x, Iso4217Code? y, int expected)
    {
        // Arrange
        var comparer = new Iso4217CodeMinorUnitsNullableComparer();

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
