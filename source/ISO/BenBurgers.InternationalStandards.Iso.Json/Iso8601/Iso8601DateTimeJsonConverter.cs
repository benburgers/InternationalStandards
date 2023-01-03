/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;
using BenBurgers.InternationalStandards.Iso.Json.Iso8601.Exceptions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BenBurgers.InternationalStandards.Iso.Json.Iso8601;

/// <summary>
/// Converts an ISO 8601 Date and Time combination from and to its JSON representation.
/// </summary>
public sealed class Iso8601DateTimeJsonConverter : JsonConverter<Iso8601DateTime>
{
    /// <inheritdoc />
    /// <exception cref="Iso8601JsonConverterException">
    /// An <see cref="Iso8601JsonConverterException" /> is thrown if the ISO 8601 Date and Time cannot be read.
    /// </exception>
    public override Iso8601DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateTimeString = reader.GetString();
        if (dateTimeString is not { Length: > 0 })
            throw new Iso8601JsonConverterException(ExceptionMessages.DateTimeCouldNotBeRead);
        try
        {
            return Iso8601DateTime.Parse(dateTimeString);
        }
        catch (Exception ex)
        {
            throw new Iso8601JsonConverterException(ExceptionMessages.DateTimeCouldNotBeRead, ex);
        }
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, Iso8601DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
