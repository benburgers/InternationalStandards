/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601CalendarDateTests
{
    public static readonly IEnumerable<object?[]> ToStringParameters =
    new[]
    {
            new object?[] { new Iso8601CalendarDate(2022, 12, 30), "2022-12-30" },
            new object?[] { new Iso8601CalendarDate(2022, 12, 30, simple: true), "20221230" },
            new object?[] { new Iso8601CalendarDate(2022, 12), "2022-12" },
            new object?[] { new Iso8601CalendarDate(2022, 12, simple: true), "202212" },
            new object?[] { new Iso8601CalendarDate(2022), "2022" },
            new object?[] { new Iso8601CalendarDate(2022, simple: true), "2022" }
    };

    [Theory(DisplayName = "Iso8601CalendarDate :: ToString")]
    [MemberData(nameof(ToStringParameters))]
    public void ToStringTests(Iso8601CalendarDate calendarDate, string expected)
    {
        var actual = calendarDate.ToString();
        Assert.Equal(expected, actual);
    }
}