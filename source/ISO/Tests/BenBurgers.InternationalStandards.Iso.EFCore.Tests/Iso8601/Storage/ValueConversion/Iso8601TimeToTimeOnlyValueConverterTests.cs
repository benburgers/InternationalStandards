/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Iso8601.Storage.ValueConversion;
using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Tests.Iso8601.Storage.ValueConversion;

public class Iso8601TimeToTimeOnlyValueConverterTests
{
    public static readonly IEnumerable<object?[]> ConverterParameters =
        new[]
        {
            new object?[] { new Iso8601Time(23, 10, 5, 0.0m), new TimeOnly(23, 10, 5) },
            new object?[] { new Iso8601Time(23, 5, 10, 0.0m), new TimeOnly(23, 5, 10) }
        };

    [Theory(DisplayName = "Iso8601TimeToTimeOnlyValueConverter :: ConvertToProvider")]
    [MemberData(nameof(ConverterParameters))]
    public void ConvertToProviderTests(Iso8601Time time, TimeOnly expected)
    {
        var valueConverter = new Iso8601TimeToTimeOnlyValueConverter();
        var actual = valueConverter.ConvertToProvider(time);
        Assert.IsType<TimeOnly>(actual);
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601TimeToTimeOnlyValueConverter :: ConvertFromProvider")]
    [MemberData(nameof(ConverterParameters))]
    public void ConvertFromProviderTests(Iso8601Time expected, TimeOnly time)
    {
        var valueConverter = new Iso8601TimeToTimeOnlyValueConverter();
        var actual = valueConverter.ConvertFromProvider(time);
        Assert.IsType<Iso8601Time>(actual);
        Assert.Equal(expected, actual);
    }
}
