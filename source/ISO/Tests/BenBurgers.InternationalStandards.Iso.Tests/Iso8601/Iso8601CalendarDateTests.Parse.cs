/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601CalendarDateTests
{
    public static readonly IEnumerable<object?[]> ParseParameters =
        new[]
        {
            new object?[] { "2023", new Iso8601CalendarDate(2023, simple: false) },
            new object?[] { "2023-01", new Iso8601CalendarDate(2023, 1, simple: false) },
            new object?[] { "202301", new Iso8601CalendarDate(2023, 1, simple: true) },
            new object?[] { "2023-01-10", new Iso8601CalendarDate(2023, 1, 10, simple: false) },
            new object?[] { "20230110", new Iso8601CalendarDate(2023, 1, 10, simple: true) }
        };

    public static readonly IEnumerable<object?[]> TryParseParameters =
        new[]
        {
            new object?[] { "2023", new Iso8601CalendarDate(2023), true },
            new object?[] { "2023x", null, false },
            new object?[] { "2023-01", new Iso8601CalendarDate(2023, 1), true },
            new object?[] { "2023-0x", null, false },
            new object?[] { "202301", new Iso8601CalendarDate(2023, 1, simple: true), true },
            new object?[] { "20230x", null, false },
            new object?[] { "2023-01-10", new Iso8601CalendarDate(2023, 1, 10), true },
            new object?[] { "2023-01-1x", null, false },
            new object?[] { "20230110", new Iso8601CalendarDate(2023, 1, 10, simple: true), true },
            new object?[] { "2023011x", null, false }
        };

    [Theory(DisplayName = "Iso8601CalendarDate :: Parse")]
    [MemberData(nameof(ParseParameters))]
    public void ParseTests(string value, Iso8601CalendarDate expected)
    {
        var actual = Iso8601CalendarDate.Parse(value);
        Assert.Equal(expected.Year, actual.Year);
        Assert.Equal(expected.Month, actual.Month);
        Assert.Equal(expected.Day, actual.Day);
        Assert.Equal(expected.Simple, actual.Simple);
    }

    [Theory(DisplayName = "Iso8601CalendarDate :: TryParse")]
    [MemberData(nameof(TryParseParameters))]
    public void TryParseTests(string value, Iso8601CalendarDate? expectedValue, bool expectedResult)
    {
        var actualResult = Iso8601CalendarDate.TryParse(value, out var actualValue);
        Assert.Equal(expectedResult, actualResult);
        Assert.Equal(expectedValue, actualValue);
    }
}
