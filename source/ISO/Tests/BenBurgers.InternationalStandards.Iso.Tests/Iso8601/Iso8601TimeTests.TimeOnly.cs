/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601TimeTests
{
    public static readonly IEnumerable<object?[]> FromTimeParameters =
        new[]
        {
            new object?[] { new TimeOnly(23, 2), new Iso8601Time(23, 2, 0, 0.0m) },
            new object?[] { new TimeOnly(23, 2), new Iso8601Time(23, 2, 0, 0.0m, TimeSpan.FromHours(2)) },
            new object?[] { new TimeOnly(23, 2, 1), new Iso8601Time(23, 2, 1, 0.0m) },
            new object?[] { new TimeOnly(23, 2, 1), new Iso8601Time(23, 2, 1, 0.0m, TimeSpan.FromHours(-3)) },
            new object?[] { new TimeOnly(23, 2, 1, 5), new Iso8601Time(23, 2, 1, 0.005m) },
            new object?[] { new TimeOnly(23, 2, 1, 5), new Iso8601Time(23, 2, 1, 0.005m, TimeSpan.FromHours(1)) },
#if NET7_0_OR_GREATER
            new object?[] { new TimeOnly(23, 2, 1, 5, 7), new Iso8601Time(23, 2, 1, 0.0057m) },
            new object?[] { new TimeOnly(23, 2, 1, 5, 7), new Iso8601Time(23, 2, 1, 0.0057m, TimeSpan.FromHours(6)) },
#endif
        };

    public static IEnumerable<object?[]> ToTimeParameters(bool includeUtcOffset)
    {
        if (includeUtcOffset)
        {
            return new[]
            {
                new object?[] { new Iso8601Time(23), null, new TimeOnly(23, 0) },
                new object?[] { new Iso8601Time(23), TimeSpan.FromHours(2), new TimeOnly(1, 0) },
                new object?[] { new Iso8601Time(23, TimeSpan.FromHours(2)), TimeSpan.FromHours(-3), new TimeOnly(18, 0) },
                new object?[] { new Iso8601Time(23, TimeSpan.FromHours(2)), null, new TimeOnly(21, 0) },
                new object?[] { new Iso8601Time(23, 30), null, new TimeOnly(23, 30) },
                new object?[] { new Iso8601Time(23, 30), TimeSpan.FromHours(2), new TimeOnly(1, 30) },
                new object?[] { new Iso8601Time(23, 30, TimeSpan.FromHours(2)), TimeSpan.FromHours(-3), new TimeOnly(18, 30) },
                new object?[] { new Iso8601Time(23, 30, TimeSpan.FromHours(2)), null, new TimeOnly(21, 30) },
                new object?[] { new Iso8601Time(23, 30, 5), null, new TimeOnly(23, 30, 5) },
                new object?[] { new Iso8601Time(23, 30, 5), TimeSpan.FromHours(2), new TimeOnly(1, 30, 5) },
                new object?[] { new Iso8601Time(23, 30, 5, TimeSpan.FromHours(2)), TimeSpan.FromHours(-3), new TimeOnly(18, 30, 5) },
                new object?[] { new Iso8601Time(23, 30, 5, TimeSpan.FromHours(2)), null, new TimeOnly(21, 30, 5) },
                new object?[] { new Iso8601Time(23, 30, 5, 0.123m), null, new TimeOnly(23, 30, 5, 123) },
                new object?[] { new Iso8601Time(23, 30, 5, 0.123m), TimeSpan.FromHours(2), new TimeOnly(1, 30, 5, 123) },
                new object?[] { new Iso8601Time(23, 30, 5, 0.123m, TimeSpan.FromHours(2)), TimeSpan.FromHours(-3), new TimeOnly(18, 30, 5, 123) },
                new object?[] { new Iso8601Time(23, 30, 5, 0.123m, TimeSpan.FromHours(2)), null, new TimeOnly(21, 30, 5, 123) }
            };
        }
        else
        {
            return new[]
            {
                new object?[] { new Iso8601Time(23), new TimeOnly(23, 0) },
                new object?[] { new Iso8601Time(23, 30), new TimeOnly(23, 30) },
                new object?[] { new Iso8601Time(23, 30, 5), new TimeOnly(23, 30, 5) },
                new object?[] { new Iso8601Time(23, 30, 5, 0.123m), new TimeOnly(23, 30, 5, 123) }
            };
        }
    }

    [Theory(DisplayName = "Iso8601Time :: Cast [TimeOnly « Iso8601Time]")]
    [MemberData(nameof(ToTimeParameters), false)]
    public void CastTimeOnlyFromIsoTimeTests(Iso8601Time time, TimeOnly expected)
    {
        var actual = (TimeOnly)time;
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601Time :: Cast [TimeOnly » Iso8601Time]")]
    [MemberData(nameof(FromTimeParameters))]
    public void CastTimeOnlyToIsoTimeTests(TimeOnly timeOnly, Iso8601Time expected)
    {
        var actual = (Iso8601Time)timeOnly;
        Assert.Equal(expected.Hour, actual.Hour);
        Assert.Equal(expected.Minute, actual.Minute);
        Assert.Equal(expected.Second, actual.Second);
        Assert.Equal(expected.Fraction, actual.Fraction);
    }

    [Theory(DisplayName = "Iso8601Time :: FromTime")]
    [MemberData(nameof(FromTimeParameters))]
    public void FromTimeTests(TimeOnly timeOnly, Iso8601Time expected)
    {
        var actual = Iso8601Time.FromTime(timeOnly, expected.UtcOffset);
        Assert.Equal(expected.Hour, actual.Hour);
        Assert.Equal(expected.Minute, actual.Minute);
        Assert.Equal(expected.Second, actual.Second);
        Assert.Equal(expected.Fraction, actual.Fraction);
        Assert.Equal(expected.UtcOffset, actual.UtcOffset);
    }

    [Theory(DisplayName = "Iso8601Time :: ToTime")]
    [MemberData(nameof(ToTimeParameters), true)]
    public void ToTimeTests(Iso8601Time time, TimeSpan? utcOffset, TimeOnly expected)
    {
        var actual = time.ToTime(utcOffset);
        Assert.Equal(expected, actual);
    }
}
