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
/// Converts an ISO 8601 Ordinal Date from and to its JSON representation.
/// </summary>
public sealed class Iso8601OrdinalDateJsonConverter : JsonConverter<Iso8601OrdinalDate>
{
    /// <inheritdoc />
    /// <exception cref="Iso8601JsonConverterException">
    /// An <see cref="Iso8601JsonConverterException" /> is thrown if the ISO 8601 Ordinal Date cannot be read.
    /// </exception>
    public override Iso8601OrdinalDate Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var ordinalDateString = reader.GetString();
        if (ordinalDateString is not { Length: > 0 })
            throw new Iso8601JsonConverterException(ExceptionMessages.OrdinalDateCouldNotBeRead);
        try
        {
            return Iso8601OrdinalDate.Parse(ordinalDateString);
        }
        catch (Exception ex)
        {
            throw new Iso8601JsonConverterException(ExceptionMessages.OrdinalDateCouldNotBeRead, ex);
        }
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, Iso8601OrdinalDate value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
