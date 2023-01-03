/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601OrdinalDateTests
{
    public static readonly IEnumerable<object?[]> CastDateTimeOffsetToOrdinalDateParameters =
        new[]
        {
            new object?[] { new DateTimeOffset(new DateTime(2022, 1, 10)), new Iso8601OrdinalDate(2022, 10) },
            new object?[] { new DateTimeOffset(new DateTime(2022, 12, 30)), new Iso8601OrdinalDate(2022, 364) }
        };

    [Theory(DisplayName = "Iso8601OrdinalDate :: Cast [DateTimeOffset » OrdinalDate]")]
    [MemberData(nameof(CastDateTimeOffsetToOrdinalDateParameters))]
    public void CastDateTimeOffsetToOrdinalDateTests(
        DateTimeOffset dateTimeOffset,
        Iso8601OrdinalDate expected)
    {
        var actual = (Iso8601OrdinalDate)dateTimeOffset;
        Assert.Equal(expected.Year, actual.Year);
        Assert.Equal(expected.DayOfYear, actual.DayOfYear);
        Assert.False(actual.Simple);
    }

    public static readonly IEnumerable<object?[]> CastDateTimeOffsetFromOrdinalDateParameters =
        new[]
        {
            new object?[] { new Iso8601OrdinalDate(2022, 10), new DateTimeOffset(new DateTime(2022, 1, 10)) },
            new object?[] { new Iso8601OrdinalDate(2022, 364), new DateTimeOffset(new DateTime(2022, 12, 30)) }
        };

    [Theory(DisplayName = "Iso8601OrdinalDate :: Cast [DateTimeOffset « OrdinalDate]")]
    [MemberData(nameof(CastDateTimeOffsetFromOrdinalDateParameters))]
    public void CastDateTimeOffsetFromOrdinalDateTests(
        Iso8601OrdinalDate ordinalDate,
        DateTimeOffset expected)
    {
        var actual = (DateTimeOffset)ordinalDate;
        Assert.Equal(expected, actual);
    }

    public static readonly IEnumerable<object?[]> FromDateTimeOffsetParameters =
        new[]
        {
            new object?[] { new DateTimeOffset(new DateTime(2022, 1, 10)), false, 2022, 10u },
            new object?[] { new DateTimeOffset(new DateTime(2022, 12, 30)), true, 2022, 364u }
        };

    [Theory(DisplayName = "Iso8601OrdinalDate :: FromDateTimeOffset")]
    [MemberData(nameof(FromDateTimeOffsetParameters))]
    public void FromDateTimeOffsetTests(
        DateTimeOffset dateTimeOffset,
        bool simple,
        int year,
        ushort dayOfYear)
    {
        var actual = Iso8601OrdinalDate.FromDateTimeOffset(dateTimeOffset, simple);
        Assert.Equal(year, actual.Year);
        Assert.Equal(dayOfYear, actual.DayOfYear);
        Assert.Equal(simple, actual.Simple);
    }
}
