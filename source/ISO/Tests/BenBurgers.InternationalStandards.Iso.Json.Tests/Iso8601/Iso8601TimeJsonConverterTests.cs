/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;
using BenBurgers.InternationalStandards.Iso.Json.Iso8601;
using System.Text.Json;

namespace BenBurgers.InternationalStandards.Iso.Json.Tests.Iso8601;

public class Iso8601TimeJsonConverterTests
{
    public record MockRecord(Iso8601Time Time);

    public static readonly IEnumerable<object?[]> ConverterParameters =
        new[]
        {
            new object?[] { "{\"Time\":\"23:20:05Z\"}", new MockRecord(new Iso8601Time(23, 20, 5, TimeSpan.Zero)) },
            new object?[] { "{\"Time\":\"23:05:20,0123\\u002B02:00\"}", new MockRecord(new Iso8601Time(23, 5, 20, 0.0123m, TimeSpan.FromHours(2))) }
        };

    [Theory(DisplayName = "Iso8601TimeJsonConverter :: Deserialize")]
    [MemberData(nameof(ConverterParameters))]
    public void DeserializeTests(string json, MockRecord expected)
    {
        // Arrange
        var options = new JsonSerializerOptions();
        options.Converters.Add(new Iso8601TimeJsonConverter());

        // Act
        var actual = JsonSerializer.Deserialize<MockRecord>(json, options);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601TimeJsonConverter :: Serialize")]
    [MemberData(nameof(ConverterParameters))]
    public void SerializeTests(string expected, MockRecord record)
    {
        // Arrange
        var options = new JsonSerializerOptions();
        options.Converters.Add(new Iso8601TimeJsonConverter());

        // Act
        var actual = JsonSerializer.Serialize(record, options);

        // Assert
        Assert.Equal(expected, actual);
    }
}
