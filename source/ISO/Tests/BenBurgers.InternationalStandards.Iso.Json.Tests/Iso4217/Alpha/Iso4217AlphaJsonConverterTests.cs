/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;
using BenBurgers.InternationalStandards.Iso.Json.Iso4217;
using BenBurgers.InternationalStandards.Iso.Json.Iso4217.Alpha;
using System.Text;
using System.Text.Json;

namespace BenBurgers.InternationalStandards.Iso.Json.Tests.Iso4217.Alpha;

public class Iso4217AlphaJsonConverterTests
{
    private record TestJson(Iso4217Code Code);

    [Fact(DisplayName = "ISO 4217 Alpha JSON Converter reads Alpha-3 codes.")]
    public async Task ReadTestAsync()
    {
        // Arrange
        const string Value = "{\"Code\":\"EUR\"}";
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(Value));

        var options = new Iso4217JsonConverterOptions();
        var jsonConverter = new Iso4217AlphaJsonConverter(options);
        var jsonSerializerOptions = new JsonSerializerOptions();
        jsonSerializerOptions.Converters.Add(jsonConverter);

        // Act
        var actual = await JsonSerializer.DeserializeAsync<TestJson>(stream, jsonSerializerOptions, CancellationToken.None);

        // Assert
        Assert.Equal(Iso4217Code.Euro, actual!.Code);
    }

    [Fact(DisplayName = "ISO 4217 Alpha JSON Converter writes Alpha-3 codes.")]
    public void WriteTest()
    {
        // Arrange
        const Iso4217Code Value = Iso4217Code.Euro;
        var testJson = new TestJson(Value);
        var options = new Iso4217JsonConverterOptions();
        var jsonConverter = new Iso4217AlphaJsonConverter(options);
        var jsonSerializerOptions = new JsonSerializerOptions();
        jsonSerializerOptions.Converters.Add(jsonConverter);

        // Act
        var actual = JsonSerializer.Serialize(testJson, jsonSerializerOptions);

        // Assert
        Assert.Equal("{\"Code\":\"EUR\"}", actual);
    }
}
