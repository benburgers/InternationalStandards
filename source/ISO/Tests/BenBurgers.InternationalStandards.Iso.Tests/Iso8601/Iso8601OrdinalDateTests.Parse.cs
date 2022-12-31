/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601OrdinalDateTests
{
    public static readonly IEnumerable<object?[]> ParseParameters =
        new[]
        {
            new object?[] { "2023-10", new Iso8601OrdinalDate(2023, 10) },
            new object?[] { "2023010", new Iso8601OrdinalDate(2023, 10, simple: true) }
        };

    public static readonly IEnumerable<object?[]> TryParseParameters =
        new[]
        {
            new object?[] { "2023-10", new Iso8601OrdinalDate(2023, 10), true },
            new object?[] { "2023x10", null, false },
            new object?[] { "2023010", new Iso8601OrdinalDate(2023, 10, simple: true), true },
            new object?[] { "2023x", null, false}
        };

    [Theory(DisplayName = "Iso8601OrdinalDate :: Parse")]
    [MemberData(nameof(ParseParameters))]
    public void ParseTests(string value, Iso8601OrdinalDate expected)
    {
        var actual = Iso8601OrdinalDate.Parse(value);
        Assert.Equal(expected.Year, actual.Year);
        Assert.Equal(expected.DayOfYear, actual.DayOfYear);
        Assert.Equal(expected.Simple, actual.Simple);
    }

    [Theory(DisplayName = "Iso8601OrdinalDate :: TryParse")]
    [MemberData(nameof(TryParseParameters))]
    public void TryParseTests(string value, Iso8601OrdinalDate? expectedValue, bool expectedResult)
    {
        var actualResult = Iso8601OrdinalDate.TryParse(value, out var actualValue);
        Assert.Equal(expectedResult, actualResult);
        Assert.Equal(expectedValue, actualValue);
    }
}
