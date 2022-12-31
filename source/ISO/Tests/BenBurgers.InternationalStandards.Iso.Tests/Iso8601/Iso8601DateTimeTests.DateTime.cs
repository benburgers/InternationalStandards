/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601DateTimeTests
{
    public static readonly IEnumerable<object?[]> FromDateTimeParameters =
        new[]
        {
            new object?[]
            {
                new DateTime(2023, 2, 2),
                new Iso8601DateTime(new Iso8601CalendarDate(2023, 2, 2), new Iso8601Time(0, 0, 0, 0.0m))
            },
            new object?[]
            {
                new DateTime(2023, 2, 2, 23, 10, 5),
                new Iso8601DateTime(new Iso8601CalendarDate(2023, 2, 2), new Iso8601Time(23, 10, 5, 0.0m))
            }
        };

    public static readonly IEnumerable<object?[]> ToDateTimeParameters =
        new[]
        {
            new object?[]
            {
                new Iso8601DateTime(new Iso8601CalendarDate(2023, 2, 2)),
                new DateTime(2023, 2, 2)
            },
            new object?[]
            {
                new Iso8601DateTime(new Iso8601Time(23, 10, 5)),
                DateTime.MinValue.AddHours(23).AddMinutes(10).AddSeconds(5)
            },
            new object?[]
            {
                new Iso8601DateTime(new Iso8601CalendarDate(2023, 2, 2), new Iso8601Time(23, 10, 5)),
                new DateTime(2023, 2, 2, 23, 10, 5)
            }
        };

    [Theory(DisplayName = "Iso8601DateTime :: Cast [DateTime » Iso8601DateTime]")]
    [MemberData(nameof(FromDateTimeParameters))]
    public void CastFromDateTimeTests(DateTime dateTime, Iso8601DateTime expected)
    {
        var actual = (Iso8601DateTime)dateTime;
        Assert.Equal(expected.Date, actual.Date);
        Assert.Equal(expected.Time, actual.Time);
    }

    [Theory(DisplayName = "Iso8601DateTime :: Cast [DateTime « Iso8601DateTime]")]
    [MemberData(nameof(ToDateTimeParameters))]
    public void CastToDateTimeTests(Iso8601DateTime dateTime, DateTime expected)
    {
        var actual = (DateTime)dateTime;
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601DateTime :: FromDateTime")]
    [MemberData(nameof(FromDateTimeParameters))]
    public void FromDateTimeTests(DateTime dateTime, Iso8601DateTime expected)
    {
        var actual = Iso8601DateTime.FromDateTime(dateTime);
        Assert.Equal(expected.Date, actual.Date);
        Assert.Equal(expected.Time, actual.Time);
    }

    [Theory(DisplayName = "Iso8601DateTime :: ToDateTime")]
    [MemberData(nameof(ToDateTimeParameters))]
    public void ToDateTimeTests(Iso8601DateTime dateTime, DateTime expected)
    {
        var actual = dateTime.ToDateTime();
        Assert.Equal(expected, actual);
    }
}
