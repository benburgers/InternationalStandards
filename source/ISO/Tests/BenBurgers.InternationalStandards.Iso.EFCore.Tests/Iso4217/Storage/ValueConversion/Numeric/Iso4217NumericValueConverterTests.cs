/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Iso4217.Storage.ValueConversion.Numeric;
using BenBurgers.InternationalStandards.Iso.Iso4217;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Tests.Iso4217.Storage.ValueConversion.Numeric;

public class Iso4217NumericValueConverterTests
{
    public static IEnumerable<object?[]> ConvertToProviderParameters =
        new[]
        {
            new object?[] { Iso4217Code.Balboa, 590 },
            new object?[] { Iso4217Code.Pataca, 446 }
        };

    [Theory(DisplayName = "ISO 4217 Numeric Value Converter converts to provider.")]
    [MemberData(nameof(ConvertToProviderParameters))]
    public void ConvertToProviderTest(Iso4217Code value, int expected)
    {
        // Arrange
        var valueConverter = new Iso4217NumericValueConverter();

        // Act
        var actual = valueConverter.ConvertToProvider(value);

        // Assert
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object?[]> ConvertFromProviderParameters =
        new[]
        {
            new object?[] { 191, Iso4217Code.Kuna },
            new object?[] { 410, Iso4217Code.Won }
        };

    [Theory(DisplayName = "ISO 4217 Numeric Value Converter converts from provider.")]
    [MemberData(nameof(ConvertFromProviderParameters))]
    public void ConvertFromProviderTest(int value, Iso4217Code expected)
    {
        // Arrange
        var valueConverter = new Iso4217NumericValueConverter();

        // Act
        var actual = valueConverter.ConvertFromProvider(value);

        // Assert
        Assert.Equal(expected, actual);
    }
}
