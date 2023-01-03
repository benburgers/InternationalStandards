/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;
using BenBurgers.InternationalStandards.Iso.Json.Iso8601;
using System.Text.Json;

namespace BenBurgers.InternationalStandards.Iso.Json.Tests.Iso8601;

public class Iso8601CalendarDateJsonConverterTests
{
    public record MockRecord(Iso8601CalendarDate CalendarDate);

    public static readonly IEnumerable<object?[]> ConverterParameters =
        new[]
        {
            new object?[] { "{\"CalendarDate\":\"2023-10-12\"}", new MockRecord(new Iso8601CalendarDate(2023, 10, 12)) },
            new object?[] { "{\"CalendarDate\":\"2023-12-10\"}", new MockRecord(new Iso8601CalendarDate(2023, 12, 10)) }
        };

    [Theory(DisplayName = "Iso8601CalendarDateJsonConverter :: Deserialize")]
    [MemberData(nameof(ConverterParameters))]
    public void DeserializeTests(string json, MockRecord expected)
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new Iso8601CalendarDateJsonConverter());
        var actual = JsonSerializer.Deserialize<MockRecord>(json, options);
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Iso8601CalendarDateJsonConverter :: Serialize")]
    [MemberData(nameof(ConverterParameters))]
    public void SerializeTests(string expected, MockRecord record)
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new Iso8601CalendarDateJsonConverter());
        var actual = JsonSerializer.Serialize(record, options);
        Assert.Equal(expected, actual);
    }
}
