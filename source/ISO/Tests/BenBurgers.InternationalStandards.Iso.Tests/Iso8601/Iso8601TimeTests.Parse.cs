/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601TimeTests
{
    public static readonly IEnumerable<object?[]> ParseParameters =
        new[]
        {
            new object?[] { "23", new Iso8601Time(23) },
            new object?[] { "23Z", new Iso8601Time(23, TimeSpan.Zero) },
            new object?[] { "23+02:00", new Iso8601Time(23, TimeSpan.FromHours(2)) },
            new object?[] { "23-03:30", new Iso8601Time(23, -new TimeSpan(3, 30, 0)) },
            new object?[] { "23:10", new Iso8601Time(23, 10) },
            new object?[] { "23:10Z", new Iso8601Time(23, 10, TimeSpan.Zero) },
            new object?[] { "23:10+02:00", new Iso8601Time(23, 10, TimeSpan.FromHours(2)) },
            new object?[] { "23:10-03:30", new Iso8601Time(23, 10, -new TimeSpan(3, 30, 0)) },
            new object?[] { "23:10:01", new Iso8601Time(23, 10, 1) },
            new object?[] { "23:10:01Z", new Iso8601Time(23, 10, 1, TimeSpan.Zero) },
            new object?[] { "23:10:01+02:00", new Iso8601Time(23, 10, 1, TimeSpan.FromHours(2)) },
            new object?[] { "23:10:01-03:30", new Iso8601Time(23, 10, 1, -new TimeSpan(3, 30, 0)) },
            new object?[] { "23:10:01,0123", new Iso8601Time(23, 10, 1, 0.0123m) },
            new object?[] { "23:10:01,0123Z", new Iso8601Time(23, 10, 1, 0.0123m, TimeSpan.Zero) },
            new object?[] { "23:10:01,0123+02:00", new Iso8601Time(23, 10, 1, 0.0123m, TimeSpan.FromHours(2)) },
            new object?[] { "23:10:01,0123-03:30", new Iso8601Time(23, 10, 1, 0.0123m, -new TimeSpan(3, 30, 0)) },

            // Simple
            new object?[] { "23+0200", new Iso8601Time(23, TimeSpan.FromHours(2), simple: true) },
            new object?[] { "23-0330", new Iso8601Time(23, -new TimeSpan(3, 30, 0), simple: true) },
            new object?[] { "2310", new Iso8601Time(23, 10, simple: true) },
            new object?[] { "2310Z", new Iso8601Time(23, 10, TimeSpan.Zero, simple: true) },
            new object?[] { "231001", new Iso8601Time(23, 10, 1, simple: true) },
            new object?[] { "231001Z", new Iso8601Time(23, 10, 1, TimeSpan.Zero, simple: true) },
            new object?[] { "231001+0200", new Iso8601Time(23, 10, 1, TimeSpan.FromHours(2), simple: true) },
            new object?[] { "231001-0330", new Iso8601Time(23, 10, 1, -new TimeSpan(3, 30, 0), simple: true) },
            new object?[] { "231001,0123", new Iso8601Time(23, 10, 1, 0.0123m, simple: true) },
            new object?[] { "231001,0123Z", new Iso8601Time(23, 10, 1, 0.0123m, TimeSpan.Zero, simple: true) },
            new object?[] { "231001,0123+0200", new Iso8601Time(23, 10, 1, 0.0123m, TimeSpan.FromHours(2), simple: true) },
            new object?[] { "231001,0123-0330", new Iso8601Time(23, 10, 1, 0.0123m, -new TimeSpan(3, 30, 0), simple: true) }
        };

    public static IEnumerable<object?[]> TryParseParameters =
        new[]
        {
            new object?[] { "23", new Iso8601Time(23), true },
            new object?[] { "23x", null, false },
            new object?[] { "23Z", new Iso8601Time(23, TimeSpan.Zero), true },
            new object?[] { "23Zx", null, false }
        };

    [Theory(DisplayName = "Iso8601Time :: Parse")]
    [MemberData(nameof(ParseParameters))]
    public void ParseTests(string value, Iso8601Time expected)
    {
        var actual = Iso8601Time.Parse(value);
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601Time :: TryParse")]
    [MemberData(nameof(TryParseParameters))]
    public void TryParseTests(string value, Iso8601Time? expectedValue, bool expectedResult)
    {
        var actualResult = Iso8601Time.TryParse(value, out var actualValue);
        Assert.Equal(expectedValue, actualValue);
        Assert.Equal(expectedResult, actualResult);
    }
}
