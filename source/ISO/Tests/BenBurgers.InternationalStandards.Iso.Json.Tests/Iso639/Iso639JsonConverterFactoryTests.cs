/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Json.Iso639;
using BenBurgers.InternationalStandards.Iso.Json.Iso639.Alpha;
using System.Text.Json;

namespace BenBurgers.InternationalStandards.Iso.Json.Tests.Iso639;

public class Iso639JsonConverterFactoryTests
{
    public static IEnumerable<object?[]> CreateConverterTestParametersList =>
        new[]
        {
            new object?[] { typeof(string), typeof(Iso639AlphaJsonConverter) }
        };

    [Theory(DisplayName = "ISO 639 JSON Converter Factory creates the appropriate JSON Converters.")]
    [MemberData(nameof(CreateConverterTestParametersList))]
    public void CreateConverterTests(Type typeToConvert, Type jsonConverterType)
    {
        // Arrange
        var iso639JsonConverterOptions = Iso639JsonConverterOptions.Default;
        var factory = new Iso639JsonConverterFactory(iso639JsonConverterOptions);
        var serializerOptions = new JsonSerializerOptions();

        // Act
        var jsonConverter = factory.CreateConverter(typeToConvert, serializerOptions);

        // Assert
        Assert.NotNull(jsonConverter);
        Assert.IsType(jsonConverterType, jsonConverter);
    }
}
