/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601DateTimeTests
{
    public static readonly IEnumerable<object?[]> ConstructorParameters =
        new[]
        {
            new object?[] { new object?[] { new Iso8601CalendarDate() }, new Iso8601CalendarDate(), null },
            new object?[] { new object?[] { new Iso8601Time(23) }, null, new Iso8601Time(23) },
            new object?[] { new object?[] { new Iso8601CalendarDate(), new Iso8601Time(23) }, new Iso8601CalendarDate(), new Iso8601Time(23) }
        };

    [Theory(DisplayName = "Iso8601DateTime :: Constructor")]
    [MemberData(nameof(ConstructorParameters))]
    public void ConstructorTests(object?[] constructorParameters, Iso8601CalendarDate? date, Iso8601Time? time)
    {
        var dateTime = (Iso8601DateTime)Activator.CreateInstance(typeof(Iso8601DateTime), constructorParameters)!;
        Assert.Equal(date, dateTime.Date);
        Assert.Equal(time, dateTime.Time);
    }
}
