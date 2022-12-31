/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601CalendarDateTests
{
    public static readonly IEnumerable<object?[]> CastDateTimeOffsetToCalendarDateParameters =
        new[]
        {
            new object?[] { new DateTimeOffset(new DateTime(2022, 10, 2)), new Iso8601CalendarDate(2022, 10, 2) },
            new object?[] { new DateTimeOffset(new DateTime(2010, 12, 1)), new Iso8601CalendarDate(2010, 12, 1) }
        };

    [Theory(DisplayName = "Iso8601CalendarDate :: Cast [DateTimeOffset » CalendarDate]")]
    [MemberData(nameof(CastDateTimeOffsetToCalendarDateParameters))]
    public void CastDateTimeOffsetToCalendarDateTests(DateTimeOffset dateTimeOffset, Iso8601CalendarDate expected)
    {
        var actual = (Iso8601CalendarDate)dateTimeOffset;
        Assert.Equal(expected.Year, actual.Year);
        Assert.Equal(expected.Month, actual.Month);
        Assert.Equal(expected.Day, actual.Day);
        Assert.False(actual.Simple);
    }

    public static readonly IEnumerable<object?[]> CastDateTimeOffsetFromCalendarDateParameters =
        new[]
        {
            new object?[] { new Iso8601CalendarDate(2022, 10, 2), new DateTimeOffset(new DateTime(2022, 10, 2)) },
            new object?[] { new Iso8601CalendarDate(2010, 12, 1), new DateTimeOffset(new DateTime(2010, 12, 1)) }
        };

    [Theory(DisplayName = "Iso8601CalendarDate :: Cast [DateTimeOffset « CalendarDate]")]
    [MemberData(nameof(CastDateTimeOffsetFromCalendarDateParameters))]
    public void CastDateTimeOffsetFromCalendarDateTests(Iso8601CalendarDate calendarDate, DateTimeOffset expected)
    {
        var actual = (DateTimeOffset)calendarDate;
        Assert.Equal(expected.Year, actual.Year);
        Assert.Equal(expected.Month, actual.Month);
        Assert.Equal(expected.Day, actual.Day);
    }

    public static readonly IEnumerable<object?[]> FromDateTimeOffsetParameters =
        new[]
        {
            new object?[] { new DateTimeOffset(new DateTime(2022, 10, 5)), false, 2022, 10, 5 },
            new object?[] { new DateTimeOffset(new DateTime(2021, 12, 3)), true, 2021, 12, 3 }
        };

    [Theory(DisplayName = "Iso8601CalendarDate :: FromDateTimeOffset")]
    [MemberData(nameof(FromDateTimeOffsetParameters))]
    public void FromDateTimeOffsetTests(
        DateTimeOffset dateTimeOffset,
        bool simple,
        int year,
        ushort month,
        ushort day)
    {
        var calendarDate = Iso8601CalendarDate.FromDateTimeOffset(dateTimeOffset, simple);
        Assert.Equal(year, calendarDate.Year);
        Assert.Equal(month, calendarDate.Month);
        Assert.Equal(day, calendarDate.Day);
        Assert.Equal(simple, calendarDate.Simple);
    }
}
