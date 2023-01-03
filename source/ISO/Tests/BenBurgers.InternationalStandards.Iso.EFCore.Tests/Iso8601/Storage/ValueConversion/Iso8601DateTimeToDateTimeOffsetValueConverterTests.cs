/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Iso8601.Storage.ValueConversion;
using BenBurgers.InternationalStandards.Iso.Iso8601;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Tests.Iso8601.Storage.ValueConversion;

public class Iso8601DateTimeToDateTimeOffsetValueConverterTests
{
    public static readonly IEnumerable<object?[]> ConverterParameters =
        new[]
        {
            new object?[]
            {
                new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 1, 10),
                    new Iso8601Time(23, 20, 5, 0.0m, TimeSpan.Zero)),
                new DateTimeOffset(new DateTime(2023, 1, 10, 23, 20, 5), TimeSpan.Zero)
            },
            new object?[]
            {
                new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 10, 1),
                    new Iso8601Time(23, 5, 20, 0.0m, TimeSpan.Zero)),
                new DateTimeOffset(new DateTime(2023, 10, 1, 23, 5, 20), TimeSpan.Zero)
            }
        };

    [Theory(DisplayName = "Iso8601DateTimeToDateTimeOffsetValueConverter :: ConvertToProvider")]
    [MemberData(nameof(ConverterParameters))]
    public void ConvertToProviderTests(Iso8601DateTime dateTime, DateTimeOffset expected)
    {
        var valueConverter = new Iso8601DateTimeToDateTimeOffsetValueConverter();
        var actual = valueConverter.ConvertToProvider(dateTime);
        Assert.IsType<DateTimeOffset>(actual);
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601DateTimeToDateTimeOffsetValueConverter :: ConvertFromProvider")]
    [MemberData(nameof(ConverterParameters))]
    public void ConvertFromProviderTests(Iso8601DateTime expected, DateTimeOffset dateTimeOffset)
    {
        var valueConverter = new Iso8601DateTimeToDateTimeOffsetValueConverter();
        var actual = valueConverter.ConvertFromProvider(dateTimeOffset);
        Assert.IsType<Iso8601DateTime>(actual);
        Assert.Equal(expected, actual);
    }
}
