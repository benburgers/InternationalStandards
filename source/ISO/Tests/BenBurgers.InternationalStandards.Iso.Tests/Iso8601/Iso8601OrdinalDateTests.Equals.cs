/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601OrdinalDateTests
{
    public static readonly IEnumerable<object?[]> EqualsParameters =
        new[]
        {
            new object?[] { new Iso8601OrdinalDate(2022, 364), null, false },
            new object?[] { new Iso8601OrdinalDate(2022, 364), new DateOnly(2022, 12, 30), true },
            new object?[] { new Iso8601OrdinalDate(2022, 364), new DateOnly(2022, 12, 31), false },
            new object?[] { new Iso8601OrdinalDate(2022, 364), new DateTime(2022, 12, 30), true },
            new object?[] { new Iso8601OrdinalDate(2022, 364), new DateTime(2022, 12, 31), false },
            new object?[] { new Iso8601OrdinalDate(2022, 364), new DateTimeOffset(new DateTime(2022, 12, 30)), true },
            new object?[] { new Iso8601OrdinalDate(2022, 364), new DateTimeOffset(new DateTime(2022, 12, 31)), false },
            new object?[] { new Iso8601OrdinalDate(2022, 364), new Iso8601CalendarDate(2022, 12, 30), true },
            new object?[] { new Iso8601OrdinalDate(2022, 364), new Iso8601CalendarDate(2022, 12, 31), false }
        };

    [Theory(DisplayName = "Iso8601OrdinalDate :: Equals")]
    [MemberData(nameof(EqualsParameters))]
    public void EqualsTests(Iso8601OrdinalDate ordinalDate, object? other, bool expected)
    {
        var actual = ordinalDate.Equals(other);
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601OrdinalDate :: ==")]
    [MemberData(nameof(EqualsParameters))]
    public void EqualsOperatorTests(Iso8601OrdinalDate ordinalDate, object? other, bool expected)
    {
        var actualLhs = ordinalDate == other;
        var actualRhs = other == ordinalDate;
        Assert.Equal(expected, actualLhs);
        Assert.Equal(expected, actualRhs);
    }

    [Theory(DisplayName = "Iso8601OrdinalDate :: !=")]
    [MemberData(nameof(EqualsParameters))]
    public void NotEqualsOperatorTests(Iso8601OrdinalDate ordinalDate, object? other, bool expectedInverse)
    {
        var expected = !expectedInverse;
        var actualLhs = ordinalDate != other;
        var actualRhs = other != ordinalDate;
        Assert.Equal(expected, actualLhs);
        Assert.Equal(expected, actualRhs);
    }
}
