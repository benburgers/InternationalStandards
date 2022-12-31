/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso8601;

public partial class Iso8601OrdinalDateTests
{
    public static readonly IEnumerable<object?[]> CastDateOnlyToOrdinalDateParameters =
        new[]
        {
            new object?[] { new DateOnly(2022, 1, 10), new Iso8601OrdinalDate(2022, 10) },
            new object?[] { new DateOnly(2022, 12, 30), new Iso8601OrdinalDate(2022, 364) }
        };

    [Theory(DisplayName = "Iso8601OrdinalDate :: Cast [DateOnly » OrdinalDate]")]
    [MemberData(nameof(CastDateOnlyToOrdinalDateParameters))]
    public void CastDateOnlyToOrdinalDateTests(DateOnly dateOnly, Iso8601OrdinalDate expected)
    {
        var actual = (Iso8601OrdinalDate)dateOnly;
        Assert.Equal(expected.Year, actual.Year);
        Assert.Equal(expected.DayOfYear, actual.DayOfYear);
    }

    public static readonly IEnumerable<object?[]> CastDateOnlyFromOrdinalDateParameters =
        new[]
        {
            new object?[] { new Iso8601OrdinalDate(2022, 10), new DateOnly(2022, 1, 10) },
            new object?[] { new Iso8601OrdinalDate(2022, 364), new DateOnly(2022, 12, 30) }
        };

    [Theory(DisplayName = "Iso8601OrdinalDate :: Cast [DateOnly « OrdinalDate]")]
    [MemberData(nameof(CastDateOnlyFromOrdinalDateParameters))]
    public void CastDateOnlyFromOrdinalDateTests(Iso8601OrdinalDate ordinalDate, DateOnly expected)
    {
        var actual = (DateOnly)ordinalDate;
        Assert.Equal(expected, actual);
    }

    public static readonly IEnumerable<object?[]> ConstructorDateOnlyParameters =
        new[]
        {
            new object?[] { new DateOnly(2022, 1, 10), false, new Iso8601OrdinalDate(2022, 10) },
            new object?[] { new DateOnly(2022, 12, 30), true, new Iso8601OrdinalDate(2022, 364, simple: true) }
        };

    [Theory(DisplayName = "Iso8601OrdinalDate :: FromDate")]
    [MemberData(nameof(ConstructorDateOnlyParameters))]
    public void ConstructorDateOnlyTests(DateOnly dateOnly, bool simple, Iso8601OrdinalDate expected)
    {
        var actual = Iso8601OrdinalDate.FromDate(dateOnly, simple);
        Assert.Equal(expected.Year, actual.Year);
        Assert.Equal(expected.DayOfYear, actual.DayOfYear);
        Assert.Equal(expected.Simple, actual.Simple);
    }
}
