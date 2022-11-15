/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using System.Text.Json;
using BenBurgers.InternationalStandards.Iso.Json.Iso3166.Alpha;
using BenBurgers.InternationalStandards.Iso.Json.Iso3166.Numeric;

namespace BenBurgers.InternationalStandards.Iso.Json.Tests.Iso3166;

public class Iso3166JsonConverterFactoryTests
{
    public static IEnumerable<object?[]> CreateConverterTestParametersList =>
        new[]
        {
            new object?[] { typeof(string), typeof(Iso3166AlphaJsonConverter) },
            new object?[] { typeof(int), typeof(Iso3166NumericJsonConverter) }
        };

    [Theory(DisplayName = "ISO 3166 JSON Converter Factory creates the appropriate JSON Converters.")]
    [MemberData(nameof(CreateConverterTestParametersList))]
    public void CreateConverterTests(Type typeToConvert, Type jsonConverterType)
    {
        // Arrange
        var iso3166JsonConverterOptions = Iso3166JsonConverterOptions.Default;
        var factory = new Iso3166JsonConverterFactory(iso3166JsonConverterOptions);
        var serializerOptions = new JsonSerializerOptions();

        // Act
        var jsonConverter = factory.CreateConverter(typeToConvert, serializerOptions);

        // Assert
        Assert.NotNull(jsonConverter);
        Assert.IsType(jsonConverterType, jsonConverter);
    }
}
