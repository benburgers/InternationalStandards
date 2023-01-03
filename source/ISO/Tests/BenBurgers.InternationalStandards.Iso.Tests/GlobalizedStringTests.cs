/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso.Tests;

public class GlobalizedStringTests
{
    public static readonly IEnumerable<object?[]> GetParameters =
        new[]
        {
            new object?[]
            {
                new GlobalizedString(new Dictionary<Iso639Code, string>
                {
                    { Iso639Code.English, "Lorem ipsum" },
                    { Iso639Code.French, "Ipsum lorem" }
                }),
                Iso639Code.English,
                "Lorem ipsum"
            },
            new object?[]
            {
                new GlobalizedString(new Dictionary<Iso639Code, string>
                {
                    { Iso639Code.English, "Lorem ipsum" },
                    { Iso639Code.French, "Ipsum lorem" }
                }, Iso639Code.English),
                Iso639Code.Telugu,
                "Lorem ipsum"
            }
        };

    [Theory(DisplayName = "GlobalizedString :: Get")]
    [MemberData(nameof(GetParameters))]
    public void GetTests(
        GlobalizedString globalizedString,
        Iso639Code languageRequested,
        string expected)
    {
        // Act
        var actual = globalizedString[languageRequested];

        // Assert
        Assert.Equal(expected, actual);
    }
}
