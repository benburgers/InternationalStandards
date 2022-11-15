/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;
using BenBurgers.InternationalStandards.Iso.Json.Iso4217.Exceptions;
using System.Text.Json;

namespace BenBurgers.InternationalStandards.Iso.Json.Iso4217.Numeric;

/// <summary>
/// Converts an <see cref="Iso4217Code" /> from and to its numeric code equivalent.
/// </summary>
public sealed class Iso4217NumericJsonConverter : Iso4217JsonConverterBase
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217NumericJsonConverter" />.
    /// </summary>
    /// <param name="options">
    /// ISO 4217 JSON Converter options.
    /// </param>
    public Iso4217NumericJsonConverter(Iso4217JsonConverterOptions options)
        : base(options)
    {
    }

    /// <inheritdoc />
    /// <exception cref="Iso4217JsonConverterException">
    /// An <see cref="Iso4217JsonConverterException" /> is thrown if the numeric code could not be read.
    /// </exception>
    public override Iso4217Code Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            var number = reader.GetInt32();
            return (Iso4217Code)number;
        }
        catch (Exception ex)
        {
            throw new Iso4217JsonConverterException(ExceptionMessages.NumericCouldNotBeRead, ex);
        }
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, Iso4217Code value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((int)value);
    }
}
