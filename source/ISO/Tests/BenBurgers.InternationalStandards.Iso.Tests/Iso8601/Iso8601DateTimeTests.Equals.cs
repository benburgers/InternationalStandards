/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601DateTimeTests
{
    public static readonly IEnumerable<object?[]> EqualsParameters =
        new[]
        {
            // null
            new object?[]
            {
                new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 1, 10),
                    new Iso8601Time(23, 10)),
                null,
                false
            },

            // DateTime
            new object?[]
            {
                new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 1, 10),
                    new Iso8601Time(23, 10)),
                new DateTime(2023, 1, 10, 23, 10, 0),
                true
            },
            new object?[]
            {
                new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 1, 11),
                    new Iso8601Time(23, 11)),
                new DateTime(2023, 1, 10, 23, 10, 0),
                false
            },

            // DateTimeOffset
            new object?[]
            {
                new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 1, 10),
                    new Iso8601Time(23, 10)),
                new DateTimeOffset(new DateTime(2023, 1, 10, 23, 10, 0), TimeSpan.Zero),
                true
            },
            new object?[]
            {
                new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 1, 11),
                    new Iso8601Time(23, 11)),
                new DateTimeOffset(new DateTime(2023, 1, 10, 23, 11, 0), TimeSpan.FromHours(2)),
                false
            },

            // ISO 8601 Date and Time
            new object?[]
            {
                new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 1, 10),
                    new Iso8601Time(23, 10)),
                new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 1, 10),
                    new Iso8601Time(23, 10)),
                true
            },
            new object?[]
            {
                new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 1, 10),
                    new Iso8601Time(23, 10)),
                new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 1, 11),
                    new Iso8601Time(23, 11)),
                false
            }
        };

    [Theory(DisplayName = "Iso8601DateTime :: Equals")]
    [MemberData(nameof(EqualsParameters))]
    public void EqualsTests(Iso8601DateTime dateTime, object? other, bool expected)
    {
        var actual = dateTime.Equals(other);
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601DateTime :: ==")]
    [MemberData(nameof(EqualsParameters))]
    public void EqualsOperatorTests(Iso8601DateTime dateTime, object? other, bool expected)
    {
        var actualLhs = dateTime == other;
        var actualRhs = other == dateTime;
        Assert.Equal(expected, actualLhs);
        Assert.Equal(expected, actualRhs);
    }

    [Theory(DisplayName = "Iso8601DateTime :: !=")]
    [MemberData(nameof(EqualsParameters))]
    public void NotEqualsOperatorTests(Iso8601DateTime dateTime, object? other, bool expectedInverse)
    {
        var expected = !expectedInverse;
        var actualLhs = dateTime != other;
        var actualRhs = other != dateTime;
        Assert.Equal(expected, actualLhs);
        Assert.Equal(expected, actualRhs);
    }
}
