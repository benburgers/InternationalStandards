/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;
using BenBurgers.InternationalStandards.Iso.Json.Iso8601.Exceptions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BenBurgers.InternationalStandards.Iso.Json.Iso8601;

/// <summary>
/// Converts an ISO 8601 Calendar Date from and to its JSON representation.
/// </summary>
public sealed class Iso8601CalendarDateJsonConverter : JsonConverter<Iso8601CalendarDate>
{
    /// <inheritdoc />
    /// <exception cref="Iso8601JsonConverterException">
    /// An <see cref="Iso8601JsonConverterException" /> is thrown if the ISO 8601 Calendar Date cannot be read.
    /// </exception>
    public override Iso8601CalendarDate Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var calendarDateString = reader.GetString();
        if (calendarDateString is not { Length: > 0 })
            throw new Iso8601JsonConverterException(ExceptionMessages.CalendarDateCouldNotBeRead);
        try
        {
            return Iso8601CalendarDate.Parse(calendarDateString);
        }
        catch (Exception ex)
        {
            throw new Iso8601JsonConverterException(ExceptionMessages.CalendarDateCouldNotBeRead, ex);
        }
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, Iso8601CalendarDate value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
