/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601OrdinalDateTests
{
    private static readonly DateOnly Today = new();

    public static readonly IEnumerable<object?[]> CastDateTimeToOrdinalDateParameters =
        new[]
        {
            new object?[] { DateTime.Now.Date, new Iso8601OrdinalDate() },
            new object?[] { new DateTime(2022, 1, 10), new Iso8601OrdinalDate(2022, 10) }
        };

    [Theory(DisplayName = "Iso8601OrdinalDate :: Cast [DateTime » OrdinalDate]")]
    [MemberData(nameof(CastDateTimeToOrdinalDateParameters))]
    public void CastDateTimeToOrdinalDateTests(
        DateTime dateTime,
        Iso8601OrdinalDate expected)
    {
        var actual = (Iso8601OrdinalDate)dateTime;
        Assert.Equal(expected.Year, actual.Year);
        Assert.Equal(expected.DayOfYear, actual.DayOfYear);
        Assert.False(actual.Simple);
    }

    public static readonly IEnumerable<object?[]> CastDateTimeFromOrdinalDateParameters =
        new[]
        {
            new object?[] { new Iso8601OrdinalDate(), DateTime.Now.Date },
            new object?[] { new Iso8601OrdinalDate(2022, 10), new DateTime(2022, 1, 10) }
        };

    [Theory(DisplayName = "Iso8601OrdinalDate :: Cast [DateTime « OrdinalDate]")]
    [MemberData(nameof(CastDateTimeFromOrdinalDateParameters))]
    public void CastDateTimeFromOrdinalDateTests(
        Iso8601OrdinalDate ordinalDate,
        DateTime expected)
    {
        var actual = (DateTime)ordinalDate;
        Assert.Equal(expected, actual);
    }

    public static readonly IEnumerable<object?[]> FromDateTimeParameters =
        new[]
        {
            new object?[] { new DateTime(), false, Today.Year, (ushort)Today.DayOfYear },
            new object?[] { new DateTime(2022, 1, 10), true, 2022, 10u }
        };

    [Theory(DisplayName = "Iso8601OrdinalDate :: FromDateTime")]
    [MemberData(nameof(FromDateTimeParameters))]
    public void FromDateTimeTests(
        DateTime dateTime,
        bool simple,
        int year,
        ushort dayOfYear)
    {
        var ordinalDate = Iso8601OrdinalDate.FromDateTime(dateTime, simple);
        Assert.Equal(year, ordinalDate.Year);
        Assert.Equal(dayOfYear, ordinalDate.DayOfYear);
        Assert.Equal(simple, ordinalDate.Simple);
    }
}
