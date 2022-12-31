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
/// Converts ISO 8601 Time from and to its JSON representation.
/// </summary>
public sealed class Iso8601TimeJsonConverter : JsonConverter<Iso8601Time>
{
    /// <inheritdoc />
    /// <exception cref="Iso8601JsonConverterException">
    /// An <see cref="Iso8601JsonConverterException" /> is thrown if the ISO 8601 Time cannot be read.
    /// </exception>
    public override Iso8601Time Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var timeString = reader.GetString();
        if (timeString is not { Length: > 0 })
            throw new Iso8601JsonConverterException(ExceptionMessages.TimeCouldNotBeRead);
        try
        {
            return Iso8601Time.Parse(timeString);
        }
        catch (Exception ex)
        {
            throw new Iso8601JsonConverterException(ExceptionMessages.TimeCouldNotBeRead, ex);
        }
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, Iso8601Time value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
