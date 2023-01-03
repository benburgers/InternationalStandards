/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601DateTimeTests
{
    public static readonly IEnumerable<object?[]> DateTimeOffsetParameters =
        new[]
        {
            new object?[]
            {
                new DateTimeOffset(new DateTime(2023, 1, 10, 23, 20, 5)),
                new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 1, 10),
                    new Iso8601Time(23, 20, 5, 0.0m, TimeZoneInfo.Local.BaseUtcOffset))
            },
            new object?[]
            {
                new DateTimeOffset(new DateTime(2023, 1, 10, 23, 20, 5), TimeSpan.FromHours(2)),
                new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 1, 10),
                    new Iso8601Time(23, 20, 5, 0.0m, TimeSpan.FromHours(2)))
            }
        };

    [Theory(DisplayName = "Iso8601DateTime :: FromDateTimeOffset")]
    [MemberData(nameof(DateTimeOffsetParameters))]
    public void FromDateTimeOffsetTests(DateTimeOffset dateTimeOffset, Iso8601DateTime expected)
    {
        var actual = Iso8601DateTime.FromDateTimeOffset(dateTimeOffset);
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601DateTime :: ToDateTimeOffset")]
    [MemberData(nameof(DateTimeOffsetParameters))]
    public void ToDateTimeOffsetTests(DateTimeOffset expected, Iso8601DateTime dateTime)
    {
        var actual = dateTime.ToDateTimeOffset();
        Assert.Equal(expected, actual);
    }
}
