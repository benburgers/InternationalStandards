/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;
using BenBurgers.InternationalStandards.Iso.Json.Iso4217;
using BenBurgers.InternationalStandards.Iso.Json.Iso4217.Numeric;
using System.Text.Json;

namespace BenBurgers.InternationalStandards.Iso.Json.Tests.Iso4217.Numeric;

public class Iso4217NumericJsonConverterTests
{
    private record TestJson(Iso4217Code Code);

    [Fact(DisplayName = "ISO 4217 JSON Converter reads numeric value.")]
    public void ReadTest()
    {
        // Arrange
        const string Value = "{\"Code\":826}";
        var options = new Iso4217JsonConverterOptions();
        var jsonConverter = new Iso4217NumericJsonConverter(options);
        var jsonSerializerOptions = new JsonSerializerOptions();
        jsonSerializerOptions.Converters.Add(jsonConverter);

        // Act
        var actual = JsonSerializer.Deserialize<TestJson>(Value, jsonSerializerOptions)!;

        // Assert
        Assert.Equal(Iso4217Code.PoundSterling, actual.Code);
    }

    [Fact(DisplayName = "ISO 4217 JSON Converter writes numeric value.")]
    public void WriteTest()
    {
        // Arrange
        const Iso4217Code Value = Iso4217Code.Rand;
        var options = new Iso4217JsonConverterOptions();
        var jsonConverter = new Iso4217NumericJsonConverter(options);
        var jsonSerializerOptions = new JsonSerializerOptions();
        jsonSerializerOptions.Converters.Add(jsonConverter);

        // Act
        var actual = JsonSerializer.Serialize(new TestJson(Value), jsonSerializerOptions)!;

        // Assert
        Assert.Equal("{\"Code\":710}", actual);
    }
}
