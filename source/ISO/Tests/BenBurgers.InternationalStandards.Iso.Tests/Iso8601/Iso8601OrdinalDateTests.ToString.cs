/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601OrdinalDateTests
{
    public static readonly IEnumerable<object?[]> ToStringParameters =
    new[]
    {
            new object?[] { new Iso8601OrdinalDate(2022, 10), "2022-010" },
            new object?[] { new Iso8601OrdinalDate(2022, 10, simple: true), "2022010" },
            new object?[] { new Iso8601OrdinalDate(1953, 214), "1953-214" },
            new object?[] { new Iso8601OrdinalDate(1953, 214, simple: true), "1953214" }
    };

    [Theory(DisplayName = "Iso8601OrdinalDate :: ToString")]
    [MemberData(nameof(ToStringParameters))]
    public void ToStringTests(Iso8601OrdinalDate ordinalDate, string expected)
    {
        var actual = ordinalDate.ToString();
        Assert.Equal(expected, actual);
    }
}
