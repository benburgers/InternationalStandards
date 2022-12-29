/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;
using BenBurgers.InternationalStandards.Iso.Iso639.Comparers;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso639.Comparers;

public class Iso639CodeAlphaPart3NullableComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { null, null, 0 },
            new object?[] { null, Iso639Code.Abadi, int.MinValue },
            new object?[] { Iso639Code.Zabana, null, int.MaxValue },
            new object?[] { Iso639Code.Baan, Iso639Code.Baba, 1 },
            new object?[] { Iso639Code.Bembe, Iso639Code.Zulu, -1 },
            new object?[] { Iso639Code.Zumaya, Iso639Code.Zumaya, 0 }
        };

    [Theory(DisplayName = "Iso639CodeAlphaPart3NullableComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(Iso639Code? x, Iso639Code? y, int expected)
    {
        // Arrange
        var comparer = new Iso639CodeAlphaPart3NullableComparer();

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
