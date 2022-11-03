/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166;
using BenBurgers.InternationalStandards.Iso.Json.Iso3166.Alpha;
using System.Text.Json;

namespace BenBurgers.InternationalStandards.Iso.Json.Tests.Iso3166.Alpha;

public class Iso3166AlphaJsonConverterTests
{
    [Fact(DisplayName = "ISO 3166 Alpha JSON Converter writes Alpha-2 codes.")]
    public void WriteTestAlpha2()
    {
        // Arrange
        const Iso3166Code Value = Iso3166Code.Barbados;
        var options = new Iso3166JsonConverterOptions(Iso3166AlphaMode.Alpha2);
        var jsonConverter = new Iso3166AlphaJsonConverter(options);
        using var stream = new MemoryStream();
        using var utf8JsonWriter = new Utf8JsonWriter(stream);

        // Act
        utf8JsonWriter.WriteStartObject();
        utf8JsonWriter.WritePropertyName("Barbados");
        jsonConverter.Write(utf8JsonWriter, Value, new JsonSerializerOptions());
        utf8JsonWriter.WriteEndObject();
        utf8JsonWriter.Flush();

        // Assert
        stream.Seek(0L, SeekOrigin.Begin);
        using var streamReader = new StreamReader(stream);
        var output = streamReader.ReadToEnd();
        Assert.Equal("{\"Barbados\":\"BB\"}", output);
    }

    [Fact(DisplayName = "ISO 3166 Alpha JSON Converter writes Alpha-3 codes.")]
    public void WriteTestAlpha3()
    {
        // Arrange
        const Iso3166Code Value = Iso3166Code.Antarctica;
        var options = new Iso3166JsonConverterOptions(Iso3166AlphaMode.Alpha3);
        var jsonConverter = new Iso3166AlphaJsonConverter(options);
        using var stream = new MemoryStream();
        using var utf8JsonWriter = new Utf8JsonWriter(stream);

        // Act
        utf8JsonWriter.WriteStartObject();
        utf8JsonWriter.WritePropertyName("Antarctica");
        jsonConverter.Write(utf8JsonWriter, Value, new JsonSerializerOptions());
        utf8JsonWriter.WriteEndObject();
        utf8JsonWriter.Flush();

        // Assert
        stream.Seek(0L, SeekOrigin.Begin);
        using var streamReader = new StreamReader(stream);
        var output = streamReader.ReadToEnd();
        Assert.Equal("{\"Antarctica\":\"ATA\"}", output);
    }
}
