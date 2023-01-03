/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166;
using BenBurgers.InternationalStandards.Iso.Json.Iso3166.Numeric;
using System.Text.Json;

namespace BenBurgers.InternationalStandards.Iso.Json.Tests.Iso3166.Numeric;

public class Iso3166NumericJsonConverterTests
{
    [Fact(DisplayName = "ISO 3166 Numeric JSON Converter writes integers.")]
    public void WriteTestInteger()
    {
        // Arrange
        const Iso3166Code Value = Iso3166Code.Aruba;
        var options = new Iso3166JsonConverterOptions(NumericAsString: false);
        var jsonConverter = new Iso3166NumericJsonConverter(options);
        using var stream = new MemoryStream();
        using var utf8JsonWriter = new Utf8JsonWriter(stream);

        // Act
        utf8JsonWriter.WriteStartObject();
        utf8JsonWriter.WritePropertyName("Aruba");
        jsonConverter.Write(utf8JsonWriter, Value, new JsonSerializerOptions());
        utf8JsonWriter.WriteEndObject();
        utf8JsonWriter.Flush();

        // Assert
        stream.Seek(0L, SeekOrigin.Begin);
        using var streamReader = new StreamReader(stream);
        var output = streamReader.ReadToEnd();
        Assert.Equal("{\"Aruba\":533}", output);
    }

    [Fact(DisplayName = "ISO 3166 Numeric JSON Converter writes string with leading zeros.")]
    public void WriteTestString()
    {
        // Arrange
        const Iso3166Code Value = Iso3166Code.Argentina;
        var options = new Iso3166JsonConverterOptions(NumericAsString: true);
        var jsonConverter = new Iso3166NumericJsonConverter(options);
        using var stream = new MemoryStream();
        using var utf8JsonWriter = new Utf8JsonWriter(stream);

        // Act
        utf8JsonWriter.WriteStartObject();
        utf8JsonWriter.WritePropertyName("Argentina");
        jsonConverter.Write(utf8JsonWriter, Value, new JsonSerializerOptions());
        utf8JsonWriter.WriteEndObject();
        utf8JsonWriter.Flush();

        // Assert
        stream.Seek(0L, SeekOrigin.Begin);
        using var streamReader = new StreamReader(stream);
        var output = streamReader.ReadToEnd();
        Assert.Equal("{\"Argentina\":\"032\"}", output);
    }
}
