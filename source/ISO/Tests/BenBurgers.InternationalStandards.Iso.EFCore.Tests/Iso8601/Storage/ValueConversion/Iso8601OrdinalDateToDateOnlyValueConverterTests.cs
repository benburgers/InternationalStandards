/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Iso8601.Storage.ValueConversion;
using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Tests.Iso8601.Storage.ValueConversion;

public class Iso8601OrdinalDateToDateOnlyValueConverterTests
{
    public static readonly IEnumerable<object?[]> ConverterParameters =
        new[]
        {
            new object?[] { new Iso8601OrdinalDate(2023, 10), new DateOnly(2023, 1, 10) },
            new object?[] { new Iso8601OrdinalDate(2023, 20), new DateOnly(2023, 1, 20) }
        };

    [Theory(DisplayName = "Iso8601OrdinalDateToDateOnlyValueConverter :: ConvertToProvider")]
    [MemberData(nameof(ConverterParameters))]
    public void ConvertToProviderTests(Iso8601OrdinalDate ordinalDate, DateOnly expected)
    {
        var valueConverter = new Iso8601OrdinalDateToDateOnlyValueConverter();
        var actual = valueConverter.ConvertToProvider(ordinalDate);
        Assert.IsType<DateOnly>(actual);
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601OrdinalDateToDateOnlyValueConverter :: ConvertFromProvider")]
    [MemberData(nameof(ConverterParameters))]
    public void ConvertFromProviderTests(Iso8601OrdinalDate expected, DateOnly date)
    {
        var valueConverter = new Iso8601OrdinalDateToDateOnlyValueConverter();
        var actual = valueConverter.ConvertFromProvider(date);
        Assert.IsType<Iso8601OrdinalDate>(actual);
        Assert.Equal(expected, actual);
    }
}
