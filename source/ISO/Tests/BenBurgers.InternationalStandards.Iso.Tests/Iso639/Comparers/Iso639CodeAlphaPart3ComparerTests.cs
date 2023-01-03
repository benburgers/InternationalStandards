/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;
using BenBurgers.InternationalStandards.Iso.Iso639.Comparers;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso639.Comparers;

public class Iso639CodeAlphaPart3ComparerTests
{
    public static readonly IEnumerable<object?[]> CompareParameters =
        new[]
        {
            new object?[] { Iso639Code.Navaho_Navajo, Iso639Code.Inuinnaqtun_Inuktitut_WesternCanadian, 1 },
            new object?[] { Iso639Code.German, Iso639Code.Zulu, -1 },
            new object?[] { Iso639Code.Kaamba, Iso639Code.Kaamba, 0 }
        };

    [Theory(DisplayName = "Iso639CodeAlphaPart3Comparer :: Compare")]
    [MemberData(nameof(CompareParameters))]
    public void CompareTests(Iso639Code x, Iso639Code y, int expected)
    {
        // Arrange
        var comparer = new Iso639CodeAlphaPart3Comparer();

        // Act
        var actual = comparer.Compare(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
}
