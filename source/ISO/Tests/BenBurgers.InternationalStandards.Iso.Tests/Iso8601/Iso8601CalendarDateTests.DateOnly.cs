/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601CalendarDateTests
{
    public static readonly IEnumerable<object?[]> CastDateOnlyToCalendarDateParameters =
        new[]
        {
            new object?[] { new DateOnly(2023, 1, 1) },
            new object?[] { new DateOnly(20, 10, 5) }
        };

    [Theory(DisplayName = "Iso8601CalendarDate :: Cast [DateOnly » CalendarDate]")]
    [MemberData(nameof(CastDateOnlyToCalendarDateParameters))]
    public void CastDateOnlyToCalendarDateTests(DateOnly dateOnly)
    {
        var calendarDate = (Iso8601CalendarDate)dateOnly;
        Assert.Equal(dateOnly, calendarDate.ToDate());
        Assert.False(calendarDate.Simple);
    }

    public static readonly IEnumerable<object?[]> CastDateOnlyFromCalendarDateParameters =
        new[]
        {
            new object?[] { new Iso8601CalendarDate(2023, 1, 1), new DateOnly(2023, 1, 1) },
            new object?[] { new Iso8601CalendarDate(20, 10, 5), new DateOnly(20, 10, 5) }
        };

    [Theory(DisplayName = "Iso8601CalendarDate :: Cast [DateOnly « CalendarDate]")]
    [MemberData(nameof(CastDateOnlyFromCalendarDateParameters))]
    public void CastDateOnlyFromCalendarDateTests(Iso8601CalendarDate calendarDate, DateOnly expected)
    {
        var actual = (DateOnly)calendarDate;
        Assert.Equal(expected, actual);
    }

    public static readonly IEnumerable<object?[]> ConstructorDateOnlyParameters =
        new[]
        {
            new object?[] { new DateOnly(2023, 1, 1), false },
            new object?[] { new DateOnly(2023, 1, 1), true },
            new object?[] { new DateOnly(20, 10, 5), false },
            new object?[] { new DateOnly(20, 10, 5), true }
        };

    [Theory(DisplayName = "Iso8601CalendarDate :: Constructor [DateOnly]")]
    [MemberData(nameof(ConstructorDateOnlyParameters))]
    public void ConstructorDateOnlyTests(DateOnly dateOnly, bool simple)
    {
        var calendarDate = new Iso8601CalendarDate(dateOnly, simple);
        Assert.Equal(dateOnly, calendarDate.ToDate());
        Assert.Equal(simple, calendarDate.Simple);
    }
}
