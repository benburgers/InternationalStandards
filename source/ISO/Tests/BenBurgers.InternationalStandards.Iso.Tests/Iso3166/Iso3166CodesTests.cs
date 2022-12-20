/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso3166;

public class Iso3166CodesTests
{
    public static IEnumerable<object?[]> QueryParameters =
        new[]
        {
            new object?[]
            {
                new Iso3166FilterOptions(
                    NumericRange:
                    new Range(1, 10)),
                new Iso3166Code[]
                {
                    Iso3166Code.Afghanistan,
                    Iso3166Code.Albania,
                    Iso3166Code.Antarctica
                }
            },
            new object?[]
            {
                new Iso3166FilterOptions(
                    Alpha2Codes: new[]
                    {
                        new Alpha2("AD"),
                        new Alpha2("AL"),
                        new Alpha2("AQ")
                    }),
                new Iso3166Code[]
                {
                    Iso3166Code.Andorra,
                    Iso3166Code.Albania,
                    Iso3166Code.Antarctica
                }
            },
            new object?[]
            {
                new Iso3166FilterOptions(
                    Alpha3Codes: new[]
                    {
                        new Alpha3("ALB"),
                        new Alpha3("REU"),
                        new Alpha3("ROU")
                    }),
                new Iso3166Code[]
                {
                    Iso3166Code.Albania,
                    Iso3166Code.Réunion,
                    Iso3166Code.Romania
                }
            }
        };

    [Theory(DisplayName = "ISO 3166 codes query returns the expected results.")]
    [MemberData(nameof(QueryParameters))]
    public void QueryTest(Iso3166FilterOptions filter, Iso3166Code[] expected)
    {
        var actual = Iso3166Codes.Query(filter).ToArray();
        Assert.Equal(expected, actual);
    }
}
