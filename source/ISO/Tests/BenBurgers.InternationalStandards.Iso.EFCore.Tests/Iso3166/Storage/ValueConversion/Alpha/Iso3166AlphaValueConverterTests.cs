/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Iso3166.Storage.ValueConversion.Alpha;
using BenBurgers.InternationalStandards.Iso.Iso3166;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Tests.Iso3166.Storage.ValueConversion.Alpha;

public class Iso3166AlphaValueConverterTests
{
    public static IEnumerable<object?[]> ConvertToProviderParameters =
        new[]
        {
            new object?[] { new Iso3166AlphaValueConverterOptions(Iso3166AlphaMode.Alpha2), Iso3166Code.Antarctica, "AQ" },
            new object?[] { new Iso3166AlphaValueConverterOptions(Iso3166AlphaMode.Alpha3), Iso3166Code.Netherlands, "NLD" }
        };

    [Theory(DisplayName = "ISO 3166 Alpha Value Converter converts to provider.")]
    [MemberData(nameof(ConvertToProviderParameters))]
    public void ConvertToProviderTest(Iso3166AlphaValueConverterOptions options, Iso3166Code value, string expected)
    {
        // Arrange
        var valueConverter = new Iso3166AlphaValueConverter(options);

        // Act
        var actual = valueConverter.ConvertToProvider(value);

        // Assert
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object?[]> ConvertFromProviderParameters =
        new[]
        {
            new object?[] { new Iso3166AlphaValueConverterOptions(Iso3166AlphaMode.Alpha2), "AL", Iso3166Code.Albania },
            new object?[] { new Iso3166AlphaValueConverterOptions(Iso3166AlphaMode.Alpha3), "DEU", Iso3166Code.Germany }
        };

    [Theory(DisplayName = "ISO 3166 Alpha Value Converter converts from provider.")]
    [MemberData(nameof(ConvertFromProviderParameters))]
    public void ConvertFromProviderTest(Iso3166AlphaValueConverterOptions options, string value, Iso3166Code expected)
    {
        // Arrange
        var valueConverter = new Iso3166AlphaValueConverter(options);

        // Act
        var actual = valueConverter.ConvertFromProvider(value);

        // Assert
        Assert.Equal(expected, actual);
    }
}
