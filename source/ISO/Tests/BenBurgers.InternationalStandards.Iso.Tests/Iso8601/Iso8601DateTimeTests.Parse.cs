/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601DateTimeTests
{
    public static readonly IEnumerable<object?[]> ParseParameters =
        new[]
        {
            new object?[]
            {
                "2023-01-10T23:12:05Z",
                new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 1, 10),
                    new Iso8601Time(23, 12, 5, TimeSpan.Zero))
            },
            new object?[]
            {
                "2023-10-01T22:05:03+02:00",
                new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 10, 1),
                    new Iso8601Time(22, 5, 3, TimeSpan.FromHours(2)))
            },
            new object?[]
            {
                "2023-12-15",
                new Iso8601DateTime(new Iso8601CalendarDate(2023, 12, 15))
            },
            new object?[]
            {
                "22:05:03,0123",
                new Iso8601DateTime(new Iso8601Time(22, 5, 3, 0.0123m))
            }
        };

    public static readonly IEnumerable<object?[]> TryParseParameters =
        new[]
        {
            new object?[]
            {
                "2023-10-01T23:30:15Z",
                true,
                new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 10, 1),
                    new Iso8601Time(23, 30, 15, TimeSpan.Zero))
            },
            new object?[]
            {
                "2023x10x01T23x30x15Z",
                false,
                null
            },
            new object?[]
            {
                "2023-10-01x23:30:15Z",
                false,
                null
            }
        };

    [Theory(DisplayName = "Iso8601DateTime :: Parse")]
    [MemberData(nameof(ParseParameters))]
    public void ParseTests(string value, Iso8601DateTime expected)
    {
        var actual = Iso8601DateTime.Parse(value);
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601DateTime :: TryParse")]
    [MemberData(nameof(TryParseParameters))]
    public void TryParseTests(string value, bool expectedResult, Iso8601DateTime? expectedValue)
    {
        var actualResult = Iso8601DateTime.TryParse(value, out var actualValue);
        Assert.Equal(expectedResult, actualResult);
        Assert.Equal(expectedValue, actualValue);
    }
}
