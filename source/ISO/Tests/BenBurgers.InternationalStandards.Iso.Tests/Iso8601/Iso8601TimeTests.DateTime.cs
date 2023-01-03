/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601TimeTests
{
    public static readonly IEnumerable<object?[]> FromDateTimeParameters =
        new[]
        {
            new object?[] { new DateTime(2022, 12, 2, 23, 10, 5), new Iso8601Time(23, 10, 5, 0.0m) },
            new object?[] { new DateTime(2022, 12, 2, 23, 10, 5, DateTimeKind.Utc), new Iso8601Time(23, 10, 5, 0.0m, TimeSpan.Zero), },
            new object?[] { new DateTime(2022, 12, 2, 23, 10, 5, DateTimeKind.Local), new Iso8601Time(23, 10, 5, 0.0m, TimeZoneInfo.Local.BaseUtcOffset), },
            new object?[] { new DateTime(2022, 12, 2, 23, 10, 5, 10), new Iso8601Time(23, 10, 5, 0.01m) },
            new object?[] { new DateTime(2022, 12, 2, 23, 10, 5, 10, DateTimeKind.Utc), new Iso8601Time(23, 10, 5, 0.01m, TimeSpan.Zero) },
            new object?[] { new DateTime(2022, 12, 2, 23, 10, 5, 10, DateTimeKind.Local), new Iso8601Time(23, 10, 5, 0.01m, TimeZoneInfo.Local.BaseUtcOffset) },
#if NET7_0_OR_GREATER
            new object?[] { new DateTime(2022, 12, 2, 23, 10, 5, 10, 7), new Iso8601Time(23, 10, 5, 0.010007m) },
            new object?[] { new DateTime(2022, 12, 2, 23, 10, 5, 10, 7, DateTimeKind.Utc), new Iso8601Time(23, 10, 5, 0.010007m, TimeSpan.Zero) },
            new object?[] { new DateTime(2022, 12, 2, 23, 10, 5, 10, 7, DateTimeKind.Local), new Iso8601Time(23, 10, 5, 0.010007m, TimeZoneInfo.Local.BaseUtcOffset) },
#endif
        };

    public static IEnumerable<object?[]> ToDateTimeParameters(bool includeKind)
    {
        var utcDate = DateTime.UtcNow.Date;
        var invertedLocalDate = utcDate - TimeZoneInfo.Local.BaseUtcOffset;

        IEnumerable<object?> CreateParameters(Iso8601Time time, DateTimeKind kind, DateTime expected)
        {
            yield return time;
            if (includeKind)
                yield return kind;
            yield return expected;
        }

        yield return CreateParameters(
            new Iso8601Time(23, 10, 2, 0.0123m),
            DateTimeKind.Unspecified,
            new DateTime(
                utcDate.Year, utcDate.Month, utcDate.Day,
                23, 10, 2, 12,
#if NET7_0_OR_GREATER
                300,
#endif
                DateTimeKind.Unspecified)
        ).ToArray();
        yield return CreateParameters(
            new Iso8601Time(23, 10, 2, 0.0123m),
            DateTimeKind.Utc,
            new DateTime(
                utcDate.Year, utcDate.Month, utcDate.Day,
                23, 10, 2, 12,
#if NET7_0_OR_GREATER
                300,
#endif
                DateTimeKind.Utc)
        ).ToArray();
        if (includeKind)
            yield return CreateParameters(
                new Iso8601Time(23, 10, 2, 0.0123m),
                DateTimeKind.Local,
                DateTime.SpecifyKind(
                    new DateTime(
                        invertedLocalDate.Year, invertedLocalDate.Month, invertedLocalDate.Day,
                        23, 10, 2, 12
#if NET7_0_OR_GREATER
                        , 300
#endif
                    )
                    + TimeZoneInfo.Local.BaseUtcOffset,
                    DateTimeKind.Local)
            ).ToArray();
    }

    [Theory(DisplayName = "Iso8601Time :: Cast [DateTime » Iso8601Time]")]
    [MemberData(nameof(FromDateTimeParameters))]
    public void CastDateTimeToIsoTime(DateTime dateTime, Iso8601Time expected)
    {
        var actual = (Iso8601Time)dateTime;
        Assert.Equal(expected.Hour, actual.Hour);
        Assert.Equal(expected.Minute, actual.Minute);
        Assert.Equal(expected.Second, actual.Second);
        Assert.Equal(expected.Fraction, actual.Fraction);
        Assert.Equal(expected.UtcOffset, actual.UtcOffset);
    }

    [Theory(DisplayName = "Iso8601Time :: Cast [DateTime « Iso8601Time]")]
    [MemberData(nameof(ToDateTimeParameters), false)]
    public void CastDateTimeFromIsoTime(Iso8601Time time, DateTime expected)
    {
        var actual = (DateTime)time;
        Assert.Equal(expected, actual);
    }


    [Theory(DisplayName = "Iso8601Time :: FromDateTime")]
    [MemberData(nameof(FromDateTimeParameters))]
    public void FromDateTimeTests(DateTime dateTime, Iso8601Time expected)
    {
        var actual = Iso8601Time.FromDateTime(dateTime);
        Assert.Equal(expected.Hour, actual.Hour);
        Assert.Equal(expected.Minute, actual.Minute);
        Assert.Equal(expected.Second, actual.Second);
        Assert.Equal(expected.Fraction, actual.Fraction);
        Assert.Equal(expected.UtcOffset, actual.UtcOffset);
    }

    [Theory(DisplayName = "Iso8601Time :: ToDateTime")]
    [MemberData(nameof(ToDateTimeParameters), true)]
    public void ToDateTimeTests(Iso8601Time time, DateTimeKind kind, DateTime expected)
    {
        var actual = time.ToDateTime(kind);
        Assert.Equal(expected, actual);
    }
}
