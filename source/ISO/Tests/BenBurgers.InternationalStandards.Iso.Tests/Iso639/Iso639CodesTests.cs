/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso639;

public class Iso639CodesTests
{
    public static IEnumerable<object[]> QueryTestParameters =
        new[]
        {
            new object[]
            {
                true,
                true,
                true,
                Iso639Scope.Macrolanguage | Iso639Scope.Individual,
                Iso639LanguageType.Living,
                false,
                173
            },
            new object[]
            {
                false,
                false,
                false,
                Iso639Scope.Individual,
                Iso639LanguageType.Living,
                false,
                7001
            }
        };

    [Theory(DisplayName = "ISO 639 query returns the expected results.")]
    [MemberData(nameof(QueryTestParameters))]
    public void QueryTests(
        bool hasIso639_1,
        bool hasIso639_2,
        bool hasIso639_3,
        Iso639Scope scope,
        Iso639LanguageType languageType,
        bool includeDeprecated,
        int expectedCount)
    {
        var filter =
            new Iso639FilterOptions(
                hasIso639_1,
                hasIso639_2,
                hasIso639_3,
                scope,
                languageType,
                includeDeprecated);
        var result = Iso639Codes.Query(filter).ToArray();
        Assert.Equal(expectedCount, result.Length);
    }
}
