/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;
using BenBurgers.InternationalStandards.Iso.Iso8601.Exceptions;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601CalendarDateTests
{
    public static readonly IEnumerable<object?[]> ConstructorParameters =
        new[]
        {
            new object?[] { 2023, 12, 12, false },
            new object?[] { 2021, 5, 10, true }
        };

    [Theory(DisplayName = "Iso8601CalendarDate :: Constructor")]
    [MemberData(nameof(ConstructorParameters))]
    public void ConstructorTests(int year, ushort month, ushort day, bool simple)
    {
        var calendarDate = new Iso8601CalendarDate(year, month, day, simple);
        Assert.Equal(year, calendarDate.Year);
        Assert.Equal(month, calendarDate.Month);
        Assert.Equal(day, calendarDate.Day);
        Assert.Equal(simple, calendarDate.Simple);
    }

    public static readonly IEnumerable<object?[]> ConstructorOutOfRangeParameters =
        new[]
        {
            new object?[] { 2023, 15, 1, "month" },
            new object?[] { 2023, 1, 32, "day" }
        };

    [Theory(DisplayName = "Iso8601CalendarDate :: Constructor out of range")]
    [MemberData(nameof(ConstructorOutOfRangeParameters))]
    public void ConstructorOutOfRangeTests(int year, ushort month, ushort day, string expected)
    {
        var exception = Assert.Throws<Iso8601CalendarDateOutOfRangeException>(() => new Iso8601CalendarDate(year, month, day));
        Assert.Equal(expected, exception.ComponentName);
    }
}
