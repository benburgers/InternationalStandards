/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;
using BenBurgers.InternationalStandards.Iso.Iso639.Comparers;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso639.Comparers;

public class Iso639CodeAlphaPart2NullableComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { Iso639Part2Type.Bibliographic, null, null, 0 },
            new object?[] { Iso639Part2Type.Terminological, null, null, 0 },
            new object?[] { Iso639Part2Type.Bibliographic, null, Iso639Code.Afrikaans, int.MinValue },
            new object?[] { Iso639Part2Type.Terminological, null, Iso639Code.Afrikaans, int.MinValue },
            new object?[] { Iso639Part2Type.Bibliographic, Iso639Code.Afrikaans, null, int.MaxValue },
            new object?[] { Iso639Part2Type.Terminological, Iso639Code.Afrikaans, null, int.MaxValue },
            new object?[] { Iso639Part2Type.Bibliographic, Iso639Code.Albanian, Iso639Code.Korean, -1 },
            new object?[] { Iso639Part2Type.Terminological, Iso639Code.Albanian, Iso639Code.Korean, 1 }
        };

    [Theory(DisplayName = "Iso639CodeAlphaPart2NullableComparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(Iso639Part2Type part2Type, Iso639Code? x, Iso639Code? y, int expected)
    {
        // Arrange
        var comparer = new Iso639CodeAlphaPart2NullableComparer(part2Type);

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
