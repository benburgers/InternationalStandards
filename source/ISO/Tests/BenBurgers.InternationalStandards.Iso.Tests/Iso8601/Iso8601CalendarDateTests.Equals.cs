/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601CalendarDateTests
{
    public static readonly IEnumerable<object?[]> EqualsParameters =
        new[]
        {
            new object?[] { new Iso8601CalendarDate(2022, 10, 5), null, false },
            new object?[] { new Iso8601CalendarDate(2022), new DateOnly(2022, 1, 1), true },
            new object?[] { new Iso8601CalendarDate(2022), new DateOnly(2022, 2, 2), false },
            new object?[] { new Iso8601CalendarDate(2022, 10), new DateOnly(2022, 10, 1), true },
            new object?[] { new Iso8601CalendarDate(2022, 10), new DateOnly(2022, 10, 2), false },
            new object?[] { new Iso8601CalendarDate(2022, 10, 5), new DateOnly(2022, 10, 5), true },
            new object?[] { new Iso8601CalendarDate(2022, 10, 5), new DateOnly(2021, 12, 1), false },
            new object?[] { new Iso8601CalendarDate(2022), new DateTime(2022, 1, 1), true },
            new object?[] { new Iso8601CalendarDate(2022, 10), new DateTime(2022, 10, 1), true },
            new object?[] { new Iso8601CalendarDate(2022, 10), new DateTime(2022, 10, 2), false },
            new object?[] { new Iso8601CalendarDate(2022, 10, 5), new DateTime(2022, 10, 5), true },
            new object?[] { new Iso8601CalendarDate(2022, 10, 5), new DateTime(2020, 2, 3), false },
            new object?[] { new Iso8601CalendarDate(2022), new DateTimeOffset(new DateTime(2022, 1, 1)), true },
            new object?[] { new Iso8601CalendarDate(2022), new DateTimeOffset(new DateTime(2022, 2, 2)), false },
            new object?[] { new Iso8601CalendarDate(2022, 10), new DateTimeOffset(new DateTime(2022, 10, 1)), true },
            new object?[] { new Iso8601CalendarDate(2022, 10), new DateTimeOffset(new DateTime(2022, 10, 2)), false },
            new object?[] { new Iso8601CalendarDate(2022, 10, 5), new DateTimeOffset(new DateTime(2022, 10, 5)), true },
            new object?[] { new Iso8601CalendarDate(2022, 10, 5), new DateTimeOffset(new DateTime(2023, 1, 20)), false },
            new object?[] { new Iso8601CalendarDate(2022, 12, 30), new Iso8601OrdinalDate(2022, 364), true },
            new object?[] { new Iso8601CalendarDate(2022, 12, 30), new Iso8601OrdinalDate(2022, 365), false }
        };

    [Theory(DisplayName = "Iso8601CalendarDate :: Equals")]
    [MemberData(nameof(EqualsParameters))]
    public void EqualsTests(Iso8601CalendarDate calendarDate, object? other, bool expected)
    {
        var actual = calendarDate.Equals(other);
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601CalendarDate :: ==")]
    [MemberData(nameof(EqualsParameters))]
    public void EqualsOperatorTests(Iso8601CalendarDate calendarDate, object? other, bool expected)
    {
        var actualLhs = calendarDate == other;
        var actualRhs = other == calendarDate;
        Assert.Equal(expected, actualLhs);
        Assert.Equal(expected, actualRhs);
    }

    [Theory(DisplayName = "Iso8601CalendarDate :: !=")]
    [MemberData(nameof(EqualsParameters))]
    public void NotEqualsOperatorTests(Iso8601CalendarDate calendarDate, object? other, bool expectedInverse)
    {
        var expected = !expectedInverse;
        var actualLhs = calendarDate != other;
        var actualRhs = other != calendarDate;
        Assert.Equal(expected, actualLhs);
        Assert.Equal(expected, actualRhs);
    }
}
