/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Iso4217.Storage.ValueConversion.Alpha;
using BenBurgers.InternationalStandards.Iso.Iso4217;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Tests.Iso4217.Storage.ValueConversion.Alpha;

public class Iso4217AlphaValueConverterTests
{
    public static IEnumerable<object?[]> ConvertToProviderParameters =
        new[]
        {
            new object?[] { Iso4217Code.ChileanPeso, "CLP" },
            new object?[] { Iso4217Code.MexicanPeso, "MXN" }
        };

    [Theory(DisplayName = "ISO 4217 Alpha Value Converter converts to provider.")]
    [MemberData(nameof(ConvertToProviderParameters))]
    public void ConvertToProviderTest(Iso4217Code value, string expected)
    {
        // Arrange
        var valueConverter = new Iso4217AlphaValueConverter();

        // Act
        var actual = valueConverter.ConvertToProvider(value);

        // Assert
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object?[]> ConvertFromProviderParameters =
        new[]
        {
            new object?[] { "UAH", Iso4217Code.Hryvnia },
            new object?[] { "INR", Iso4217Code.IndianRupee }
        };

    [Theory(DisplayName = "ISO 4217 Alpha Value Converter converts from provider.")]
    [MemberData(nameof(ConvertFromProviderParameters))]
    public void ConvertFromProviderTest(string value, Iso4217Code expected)
    {
        // Arrange
        var valueConverter = new Iso4217AlphaValueConverter();

        // Act
        var actual = valueConverter.ConvertFromProvider(value);

        // Assert
        Assert.Equal(expected, actual);
    }
}
