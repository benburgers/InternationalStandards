/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Iso8601.Storage.ValueConversion;
using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Tests.Iso8601.Storage.ValueConversion;

public class Iso8601CalendarDateToDateOnlyValueConverterTests
{
    public static readonly IEnumerable<object?[]> ConverterParameters =
        new[]
        {
            new object?[] { new Iso8601CalendarDate(2023, 1, 10), new DateOnly(2023, 1, 10) },
            new object?[] { new Iso8601CalendarDate(2023, 10, 1), new DateOnly(2023, 10, 1) }
        };

    [Theory(DisplayName = "Iso8601CalendarDateToDateOnlyValueConverter :: ConvertToProvider")]
    [MemberData(nameof(ConverterParameters))]
    public void ConvertToProviderTests(Iso8601CalendarDate date, DateOnly expected)
    {
        var valueConverter = new Iso8601CalendarDateToDateOnlyValueConverter();
        var actual = valueConverter.ConvertToProvider(date);
        Assert.IsType<DateOnly>(actual);
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601CalendarDateToDateOnlyValueConverter :: ConvertFromProvider")]
    [MemberData(nameof(ConverterParameters))]
    public void ConvertFromProviderTests(Iso8601CalendarDate expected, DateOnly date)
    {
        var valueConverter = new Iso8601CalendarDateToDateOnlyValueConverter();
        var actual = valueConverter.ConvertFromProvider(date);
        Assert.IsType<Iso8601CalendarDate>(actual);
        Assert.Equal(expected, actual);
    }
}
