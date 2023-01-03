/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Iso639.Storage.ValueConversion.Alpha;
using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Tests.Iso639.Storage.ValueConversion.Alpha;

public class Iso639AlphaValueConverterTests
{
    private static readonly Iso639AlphaValueConverterOptions OptionsDefault = new Iso639AlphaValueConverterOptions();
    private static readonly Iso639AlphaValueConverterOptions OptionsAlpha1 = new Iso639AlphaValueConverterOptions(Iso639Part.Part1);
    private static readonly Iso639AlphaValueConverterOptions OptionsAlpha3 = new Iso639AlphaValueConverterOptions(Iso639Part.Part3);

    public static readonly IEnumerable<object?[]> ConvertToProviderParameters =
        new[]
        {
            new object?[] { Iso639Code.Aari, OptionsAlpha3, "aiw" },
            new object?[] { Iso639Code.Castilian_Spanish, OptionsAlpha1, "es" }
        };

    [Theory(DisplayName = "ISO 639 Alpha Value Converter converts to provider.")]
    [MemberData(nameof(ConvertToProviderParameters))]
    public void ConvertToProviderTest(Iso639Code value, Iso639AlphaValueConverterOptions options, string expected)
    {
        // Arrange
        var valueConverter = new Iso639AlphaValueConverter(options);

        // Act
        var actual = valueConverter.ConvertToProvider(value);

        // Assert
        Assert.Equal(expected, actual);
    }

    public static readonly IEnumerable<object?[]> ConvertFromProviderParameters =
        new[]
        {
            new object?[] { "aba", OptionsDefault, Iso639Code.Abé },
            new object?[] { "vi", OptionsDefault, Iso639Code.Vietnamese }
        };

    [Theory(DisplayName = "ISO 639 Alpha Value Converter converts from provider.")]
    [MemberData(nameof(ConvertFromProviderParameters))]
    public void ConvertFromProviderTest(string value, Iso639AlphaValueConverterOptions options, Iso639Code expected)
    {
        // Arrange
        var valueConverter = new Iso639AlphaValueConverter(options);

        // Act
        var actual = valueConverter.ConvertFromProvider(value);

        // Assert
        Assert.Equal(expected, actual);
    }
}
