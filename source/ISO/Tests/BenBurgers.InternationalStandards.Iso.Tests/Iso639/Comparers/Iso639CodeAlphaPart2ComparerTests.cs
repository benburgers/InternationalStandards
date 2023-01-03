/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;
using BenBurgers.InternationalStandards.Iso.Iso639.Comparers;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso639.Comparers;

public class Iso639CodeAlphaPart2ComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { Iso639Part2Type.Bibliographic, Iso639Code.Italian, Iso639Code.Japanese, -1 },
            new object?[] { Iso639Part2Type.Terminological, Iso639Code.Italian, Iso639Code.Japanese, -1 },
            new object?[] { Iso639Part2Type.Bibliographic, Iso639Code.Castilian_Spanish, Iso639Code.Dutch_Flemish, 1 },
            new object?[] { Iso639Part2Type.Terminological, Iso639Code.Castilian_Spanish, Iso639Code.Dutch_Flemish, 1 },
            new object?[] { Iso639Part2Type.Bibliographic, Iso639Code.Albanian, Iso639Code.Navaho_Navajo, -1 },
            new object?[] { Iso639Part2Type.Terminological, Iso639Code.Albanian, Iso639Code.Navaho_Navajo, 1 }
        };

    [Theory(DisplayName = "Iso639CodeAlphaPart2Comparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(Iso639Part2Type part2Type, Iso639Code x, Iso639Code y, int expected)
    {
        // Arrange
        var comparer = new Iso639CodeAlphaPart2Comparer(part2Type);

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
