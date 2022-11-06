/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166;
using System.Text.Json;

namespace BenBurgers.InternationalStandards.Iso.Json.Iso3166.Numeric;

/// <summary>
/// Converts a <see cref="Iso3166Code" /> from and to its numeric code equivalent.
/// </summary>
public sealed class Iso3166NumericJsonConverter : Iso3166JsonConverterBase
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166NumericJsonConverter" />.
    /// </summary>
    /// <param name="options">
    /// The ISO 3166 JSON Converter options.
    /// </param>
    public Iso3166NumericJsonConverter(Iso3166JsonConverterOptions options)
        : base(options)
    {
    }

    /// <inheritdoc />
    public override Iso3166Code Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return Options.NumericAsString
            ? (Iso3166Code)int.Parse(reader.GetString()!)
            : (Iso3166Code)reader.GetInt32();
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, Iso3166Code value, JsonSerializerOptions options)
    {
        if (Options.NumericAsString)
            writer.WriteStringValue(((int)value).ToString("D3"));
        else
            writer.WriteNumberValue((int)value);
    }
}
