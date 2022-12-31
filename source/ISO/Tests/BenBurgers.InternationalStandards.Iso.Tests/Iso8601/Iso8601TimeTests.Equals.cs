/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601TimeTests
{
    public static IEnumerable<object?[]> EqualsParameters()
    {
        var utcToday = DateTime.UtcNow.Date;
        return new[]
        {
            new object?[] { new Iso8601Time(23), null, false },
            new object?[] { new Iso8601Time(23), new TimeOnly(23, 0), true },
            new object?[] { new Iso8601Time(23), new TimeOnly(23, 5), false },
            new object?[] { new Iso8601Time(23), utcToday.AddHours(23), true },
            new object?[] { new Iso8601Time(23), utcToday.AddHours(23).AddMinutes(1), false },
            new object?[] { new Iso8601Time(23), new DateTimeOffset(utcToday.AddHours(23)), true },
            new object?[] { new Iso8601Time(23), new DateTimeOffset(utcToday.AddHours(23).AddMinutes(1)), false },
            new object?[] { new Iso8601Time(23), new Iso8601Time(23), true },
            new object?[] { new Iso8601Time(23), new Iso8601Time(22), false },
            new object?[] { new Iso8601Time(23, 10), new TimeOnly(23, 10), true },
            new object?[] { new Iso8601Time(23, 10), new TimeOnly(23, 11), false },
            new object?[] { new Iso8601Time(23, 10), utcToday.AddHours(23).AddMinutes(10), true },
            new object?[] { new Iso8601Time(23, 10), utcToday.AddHours(23).AddMinutes(11), false},
            new object?[] { new Iso8601Time(23, 10), new DateTimeOffset(utcToday.AddHours(23).AddMinutes(10)), true },
            new object?[] { new Iso8601Time(23, 10), new DateTimeOffset(utcToday.AddHours(23).AddMinutes(11)), false },
            new object?[] { new Iso8601Time(23, 10), new Iso8601Time(23, 10), true },
            new object?[] { new Iso8601Time(23, 10), new Iso8601Time(23, 11), false }
        };
    }


    [Theory(DisplayName = "Iso8601Time :: Equals")]
    [MemberData(nameof(EqualsParameters))]
    public void EqualsTests(Iso8601Time time, object? other, bool expected)
    {
        var actual = time.Equals(other);
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601Time :: ==")]
    [MemberData(nameof(EqualsParameters))]
    public void EqualsOperatorTests(Iso8601Time time, object? other, bool expected)
    {
        var actualLhs = time == other;
        var actualRhs = other == time;
        Assert.Equal(expected, actualLhs);
        Assert.Equal(expected, actualRhs);
    }

    [Theory(DisplayName = "Iso8601Time :: !=")]
    [MemberData(nameof(EqualsParameters))]
    public void NotEqualsOperatorTests(Iso8601Time time, object? other, bool expectedInverse)
    {
        var expected = !expectedInverse;
        var actualLhs = time != other;
        var actualRhs = other != time;
        Assert.Equal(expected, actualLhs);
        Assert.Equal(expected, actualRhs);
    }
}
