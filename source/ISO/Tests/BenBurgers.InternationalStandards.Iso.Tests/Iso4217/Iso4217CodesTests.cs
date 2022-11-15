/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso4217;

public class Iso4217CodesTests
{
    public static IEnumerable<object?[]> QueryParameters =
        new[]
        {
            new object?[] { new Iso4217FilterOptions(Entity: "NETHERLANDS"), new Iso4217Code[] { Iso4217Code.Euro } },
            new object?[] { new Iso4217FilterOptions(CurrencyName: "Lek"), new Iso4217Code[] { Iso4217Code.Lek } },
            new object?[] { new Iso4217FilterOptions(CurrencyCodes: new Alpha3[] { new("EUR"), new("GBP") }), new Iso4217Code[] { Iso4217Code.Euro, Iso4217Code.PoundSterling } }
        };

    [Theory(DisplayName = "ISO 4217 codes query returns the expected results.")]
    [MemberData(nameof(QueryParameters))]
    public void QueryTest(Iso4217FilterOptions filter, Iso4217Code[] expected)
    {
        var actual = Iso4217Codes.Query(filter).ToArray();
        Assert.Equal(expected, actual);
    }
}
