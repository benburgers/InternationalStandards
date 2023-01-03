/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;
using BenBurgers.InternationalStandards.Iso.Json.Iso8601;
using System.Text.Json;

namespace BenBurgers.InternationalStandards.Iso.Json.Tests.Iso8601;

public class Iso8601DateTimeJsonConverterTests
{
    public record MockRecord(Iso8601DateTime DateTime);

    public static readonly IEnumerable<object?[]> ConverterParameters =
        new[]
        {
            new object?[]
            {
                "{\"DateTime\":\"2023-10-01T23:20:05Z\"}",
                new MockRecord(new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 10, 1),
                    new Iso8601Time(23, 20, 5, TimeSpan.Zero)))
            },
            new object?[]
            {
                "{\"DateTime\":\"2023-01-10T20:23:50\\u002B02:00\"}",
                new MockRecord(new Iso8601DateTime(
                    new Iso8601CalendarDate(2023, 1, 10),
                    new Iso8601Time(20, 23, 50, TimeSpan.FromHours(2))))
            }
        };

    [Theory(DisplayName = "Iso8601DateTimeJsonConverter :: Deserialize")]
    [MemberData(nameof(ConverterParameters))]
    public void DeserializeTests(string json, MockRecord expected)
    {
        // Arrange
        var options = new JsonSerializerOptions();
        options.Converters.Add(new Iso8601DateTimeJsonConverter());

        // Act
        var actual = JsonSerializer.Deserialize<MockRecord>(json, options);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601DateTimeJsonConverter :: Serialize")]
    [MemberData(nameof(ConverterParameters))]
    public void SerializeTests(string expected, MockRecord record)
    {
        // Arrange
        var options = new JsonSerializerOptions();
        options.Converters.Add(new Iso8601DateTimeJsonConverter());

        // Act
        var actual = JsonSerializer.Serialize(record, options);

        // Assert
        Assert.Equal(expected, actual);
    }
}
