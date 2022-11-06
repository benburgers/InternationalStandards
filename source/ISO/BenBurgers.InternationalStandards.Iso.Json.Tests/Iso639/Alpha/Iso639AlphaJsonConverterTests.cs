/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;
using BenBurgers.InternationalStandards.Iso.Json.Iso639;
using BenBurgers.InternationalStandards.Iso.Json.Iso639.Alpha;
using System.Text.Json;

namespace BenBurgers.InternationalStandards.Iso.Json.Tests.Iso639.Alpha;

public class Iso639AlphaJsonConverterTests
{
    [Fact(DisplayName = "ISO 639 Alpha JSON Converter writes ISO 639-1 Alpha-2 codes.")]
    public void WriteTestPart1()
    {
        // Arrange
        const Iso639Code Value = Iso639Code.Dutch_Flemish;
        var options = new Iso639JsonConverterOptions(Iso639AlphaMode.Part1);
        var jsonConverter = new Iso639AlphaJsonConverter(options);
        using var stream = new MemoryStream();
        using var utf8JsonWriter = new Utf8JsonWriter(stream);

        // Act
        utf8JsonWriter.WriteStartObject();
        utf8JsonWriter.WritePropertyName("Dutch,Flemish");
        jsonConverter.Write(utf8JsonWriter, Value, new JsonSerializerOptions());
        utf8JsonWriter.WriteEndObject();
        utf8JsonWriter.Flush();

        // Assert
        stream.Seek(0L, SeekOrigin.Begin);
        using var streamReader = new StreamReader(stream);
        var output = streamReader.ReadToEnd();
        Assert.Equal("{\"Dutch,Flemish\":\"nl\"}", output);
    }

    [Fact(DisplayName = "ISO 639 Alpha JSON Converter writes ISO 639-2T Alpha-3 codes.")]
    public void WriteTestPart2T()
    {
        // Arrange
        const Iso639Code Value = Iso639Code.Albanian;
        var options = new Iso639JsonConverterOptions(Iso639AlphaMode.Part2T);
        var jsonConverter = new Iso639AlphaJsonConverter(options);
        using var stream = new MemoryStream();
        using var utf8JsonWriter = new Utf8JsonWriter(stream);

        // Act
        utf8JsonWriter.WriteStartObject();
        utf8JsonWriter.WritePropertyName("Albanian");
        jsonConverter.Write(utf8JsonWriter, Value, new JsonSerializerOptions());
        utf8JsonWriter.WriteEndObject();
        utf8JsonWriter.Flush();

        // Assert
        stream.Seek(0L, SeekOrigin.Begin);
        using var streamReader = new StreamReader(stream);
        var output = streamReader.ReadToEnd();
        Assert.Equal("{\"Albanian\":\"sqi\"}", output);
    }

    [Fact(DisplayName = "ISO 639 Alpha JSON Converter writes ISO 639-2B Alpha-3 codes.")]
    public void WriteTestPart2B()
    {
        // Arrange
        const Iso639Code Value = Iso639Code.Albanian;
        var options = new Iso639JsonConverterOptions(Iso639AlphaMode.Part2B);
        var jsonConverter = new Iso639AlphaJsonConverter(options);
        using var stream = new MemoryStream();
        using var utf8JsonWriter = new Utf8JsonWriter(stream);

        // Act
        utf8JsonWriter.WriteStartObject();
        utf8JsonWriter.WritePropertyName("Albanian");
        jsonConverter.Write(utf8JsonWriter, Value, new JsonSerializerOptions());
        utf8JsonWriter.WriteEndObject();
        utf8JsonWriter.Flush();

        // Assert
        stream.Seek(0L, SeekOrigin.Begin);
        using var streamReader = new StreamReader(stream);
        var output = streamReader.ReadToEnd();
        Assert.Equal("{\"Albanian\":\"alb\"}", output);
    }

    [Fact(DisplayName = "ISO 639 Alpha JSON Converter writes ISO 639-3 Alpha-3 codes.")]
    public void WriteTestPart3()
    {
        // Arrange
        const Iso639Code Value = Iso639Code.Arabic;
        var options = new Iso639JsonConverterOptions(Iso639AlphaMode.Part3);
        var jsonConverter = new Iso639AlphaJsonConverter(options);
        using var stream = new MemoryStream();
        using var utf8JsonWriter = new Utf8JsonWriter(stream);

        // Act
        utf8JsonWriter.WriteStartObject();
        utf8JsonWriter.WritePropertyName("Arabic");
        jsonConverter.Write(utf8JsonWriter, Value, new JsonSerializerOptions());
        utf8JsonWriter.WriteEndObject();
        utf8JsonWriter.Flush();

        // Assert
        stream.Seek(0L, SeekOrigin.Begin);
        using var streamReader = new StreamReader(stream);
        var output = streamReader.ReadToEnd();
        Assert.Equal("{\"Arabic\":\"ara\"}", output);
    }
}
