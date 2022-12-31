/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601CalendarDateTests
{
    private static readonly DateOnly Today = new();

    public static readonly IEnumerable<object?[]> CastDateTimeToCalendarDateParameters =
        new[]
        {
            new object?[] { DateTime.Now.Date, new Iso8601CalendarDate() },
            new object?[] { new DateTime(2022, 10, 2), new Iso8601CalendarDate(2022, 10, 2) }
        };

    [Theory(DisplayName = "Iso8601CalendarDate :: Cast [DateTime » CalendarDate]")]
    [MemberData(nameof(CastDateTimeToCalendarDateParameters))]
    public void CastDateTimeToCalendarDateTests(
        DateTime dateTime,
        Iso8601CalendarDate expected)
    {
        var actual = (Iso8601CalendarDate)dateTime;
        Assert.Equal(expected.Year, actual.Year);
        Assert.Equal(expected.Month, actual.Month);
        Assert.Equal(expected.Day, actual.Day);
        Assert.False(actual.Simple);
    }

    public static readonly IEnumerable<object?[]> CastDateTimeFromCalendarDateParameters =
        new[]
        {
            new object?[] { new Iso8601CalendarDate(), DateTime.Now.Date },
            new object?[] { new Iso8601CalendarDate(2022, 10, 2), new DateTime(2022, 10, 2) }
        };

    [Theory(DisplayName = "Iso8601CalendarDate :: Cast [DateTime « CalendarDate]")]
    [MemberData(nameof(CastDateTimeFromCalendarDateParameters))]
    public void CastDateTimeFromCalendarDateTests(
        Iso8601CalendarDate calendarDate,
        DateTime expected)
    {
        var actual = (DateTime)calendarDate;
        Assert.Equal(expected, actual);
    }

    public static readonly IEnumerable<object?[]> FromDateTimeParameters =
        new[]
        {
            new object?[] { new DateTime(), false, Today.Year, (ushort)Today.Month, (ushort)Today.Day },
            new object?[] { new DateTime(2020, 12, 1), true, 2020, 12u, 1u }
        };

    [Theory(DisplayName = "Iso8601CalendarDate :: FromDateTime")]
    [MemberData(nameof(FromDateTimeParameters))]
    public void FromDateTimeTests(
        DateTime dateTime,
        bool simple,
        int year,
        ushort month,
        ushort day)
    {
        var calendarDate = Iso8601CalendarDate.FromDateTime(dateTime, simple);
        Assert.Equal(year, calendarDate.Year);
        Assert.Equal(month, calendarDate.Month);
        Assert.Equal(day, calendarDate.Day);
        Assert.Equal(simple, calendarDate.Simple);
    }
}
