/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Iso3166.Storage.ValueConversion.Numeric;
using BenBurgers.InternationalStandards.Iso.Iso3166;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Tests.Iso3166.Storage.ValueConversion.Numeric;

public class Iso3166NumericValueConverterTests
{
    public static IEnumerable<object?[]> ConvertToProviderParameters =
        new[]
        {
            new object?[] { Iso3166Code.Greece, 300 },
            new object?[] { Iso3166Code.Moldova_theRepublicOf, 498 }
        };

    [Theory(DisplayName = "ISO 3166 Numeric Value Converter converts to numeric code.")]
    [MemberData(nameof(ConvertToProviderParameters))]
    public void ConvertToProviderTest(Iso3166Code value, int expected)
    {
        // Arrange
        var valueConverter = new Iso3166NumericValueConverter();

        // Act
        var actual = valueConverter.ConvertToProvider(value);

        // Assert
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object?[]> ConvertFromProviderParameters =
        new[]
        {
            new object?[] { 204, Iso3166Code.Benin },
            new object?[] { 520, Iso3166Code.Nauru }
        };

    [Theory(DisplayName = "ISO 3166 Numeric Value Converter converts from numeric code.")]
    [MemberData(nameof(ConvertFromProviderParameters))]
    public void ConvertFromProviderTest(int value, Iso3166Code expected)
    {
        // Arrange
        var valueConverter = new Iso3166NumericValueConverter();

        // Act
        var actual = valueConverter.ConvertFromProvider(value);

        // Assert
        Assert.Equal(expected, actual);
    }
}
