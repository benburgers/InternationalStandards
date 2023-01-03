/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166;
using BenBurgers.InternationalStandards.Iso.Json.Iso3166.Exceptions;
using System.Text.Json;

namespace BenBurgers.InternationalStandards.Iso.Json.Iso3166.Alpha;

/// <summary>
/// Converts a <see cref="Iso3166Code" /> from and to its Alpha-2 two-letter code equivalent.
/// </summary>
public sealed class Iso3166AlphaJsonConverter : Iso3166JsonConverterBase
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166AlphaJsonConverter" />.
    /// </summary>
    /// <param name="options">
    /// The ISO 3166 JSON Converter options.
    /// </param>
    public Iso3166AlphaJsonConverter(Iso3166JsonConverterOptions options)
        : base(options)
    {
    }

    /// <inheritdoc />
    /// <exception cref="Iso3166JsonConverterException">
    /// An <see cref="Iso3166JsonConverterException" /> is thrown if the JSON converter could not read a valid Alpha code for ISO 3166.
    /// </exception>
    public override Iso3166Code Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            var alphaString = reader.GetString()!;
            if (this.Options.CaseInsensitive)
                alphaString = alphaString.ToUpperInvariant();
            return alphaString.ToIso3166();
        }
        catch (Exception ex)
        {
            throw new Iso3166JsonConverterException(ExceptionMessages.AlphaCouldNotBeRead, ex);
        }
    }

    /// <inheritdoc />
    /// <exception cref="Iso3166JsonConverterException">
    /// An <see cref="Iso3166JsonConverterException" /> is thrown if the <see cref="Iso3166JsonConverterOptions" /> specifies an unsupported <see cref="Iso3166AlphaMode" />.
    /// </exception>
    public override void Write(Utf8JsonWriter writer, Iso3166Code value, JsonSerializerOptions options)
    {
        switch (this.Options.AlphaMode)
        {
            case Iso3166AlphaMode.Alpha2:
                writer.WriteStringValue(value.ToAlpha2());
                break;
            case Iso3166AlphaMode.Alpha3:
                writer.WriteStringValue(value.ToAlpha3());
                break;
            default:
                throw new Iso3166JsonConverterException(ExceptionMessages.AlphaModeNotSupported);
        }
    }
}
