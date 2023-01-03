/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601TimeTests
{
    public static IEnumerable<object?[]> DateTimeOffsetParameters()
    {
        var utcToday = DateTimeOffset.UtcNow.Date;
        return new[]
        {
            new object?[]
            {
                new DateTimeOffset(utcToday.Year, utcToday.Month, utcToday.Day, 23, 10, 5, TimeSpan.FromHours(2)),
                new Iso8601Time(23, 10, 5, 0.0m, TimeSpan.FromHours(2))
            },
            new object?[]
            {
                new DateTimeOffset(utcToday.Year, utcToday.Month, utcToday.Day, 23, 10, 5, 12, TimeSpan.FromHours(-3)),
                new Iso8601Time(23, 10, 5, 0.012m, TimeSpan.FromHours(-3))
            },
#if NET7_0_OR_GREATER
            new object?[]
            {
                new DateTimeOffset(utcToday.Year, utcToday.Month, utcToday.Day, 23, 10, 5, 12, 17, TimeSpan.FromHours(6)),
                new Iso8601Time(23, 10, 5, 0.012017m, TimeSpan.FromHours(6))
            },
#endif
        };
    }


    [Theory(DisplayName = "Iso8601Time :: FromDateTimeOffset")]
    [MemberData(nameof(DateTimeOffsetParameters))]
    public void FromDateTimeOffsetTests(DateTimeOffset dateTimeOffset, Iso8601Time expected)
    {
        var actual = Iso8601Time.FromDateTimeOffset(dateTimeOffset);
        Assert.Equal(expected.Hour, actual.Hour);
        Assert.Equal(expected.Minute, actual.Minute);
        Assert.Equal(expected.Second, actual.Second);
        Assert.Equal(expected.Fraction, actual.Fraction);
        Assert.Equal(expected.UtcOffset, actual.UtcOffset);
    }

    [Theory(DisplayName = "Iso8601Time :: ToDateTimeOffset")]
    [MemberData(nameof(DateTimeOffsetParameters))]
    public void ToDateTimeOffsetTests(DateTimeOffset expected, Iso8601Time time)
    {
        var actual = time.ToDateTimeOffset();
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601Time :: Cast [DateTimeOffset » Iso8601Time]")]
    [MemberData(nameof(DateTimeOffsetParameters))]
    public void CastFromDateTimeOffsetTests(DateTimeOffset dateTimeOffset, Iso8601Time expected)
    {
        var actual = (Iso8601Time)dateTimeOffset;
        Assert.Equal(expected.Hour, actual.Hour);
        Assert.Equal(expected.Minute, actual.Minute);
        Assert.Equal(expected.Second, actual.Second);
        Assert.Equal(expected.Fraction, actual.Fraction);
        Assert.Equal(expected.UtcOffset, actual.UtcOffset);
    }

    [Theory(DisplayName = "Iso8601Time :: Cast [DateTimeOffset « Iso8601Time]")]
    [MemberData(nameof(DateTimeOffsetParameters))]
    public void CastToDateTimeOffsetTests(DateTimeOffset expected, Iso8601Time time)
    {
        var actual = (DateTimeOffset)time;
        Assert.Equal(expected, actual);
    }
}
