/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;
using BenBurgers.InternationalStandards.Iso.Json.Iso8601;
using System.Text.Json;

namespace BenBurgers.InternationalStandards.Iso.Json.Tests.Iso8601;

public class Iso8601OrdinalDateJsonConverterTests
{
    public record MockRecord(Iso8601OrdinalDate OrdinalDate);

    public static readonly IEnumerable<object?[]> ConverterParameters =
        new[]
        {
            new object?[] { "{\"OrdinalDate\":\"2023-010\"}", new MockRecord(new Iso8601OrdinalDate(2023, 10)) },
            new object?[] { "{\"OrdinalDate\":\"2023-020\"}", new MockRecord(new Iso8601OrdinalDate(2023, 20)) }
        };

    [Theory(DisplayName = "Iso8601OrdinalDateJsonConverter :: Deserialize")]
    [MemberData(nameof(ConverterParameters))]
    public void DeserializeTests(string json, MockRecord expected)
    {
        // Arrange
        var options = new JsonSerializerOptions();
        options.Converters.Add(new Iso8601OrdinalDateJsonConverter());

        // Act
        var actual = JsonSerializer.Deserialize<MockRecord>(json, options);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601OrdinalDateJsonConverter :: Serialize")]
    [MemberData(nameof(ConverterParameters))]
    public void SerializeTests(string expected, MockRecord record)
    {
        // Arrange
        var options = new JsonSerializerOptions();
        options.Converters.Add(new Iso8601OrdinalDateJsonConverter());

        // Act
        var actual = JsonSerializer.Serialize(record, options);

        // Assert
        Assert.Equal(expected, actual);
    }
}
