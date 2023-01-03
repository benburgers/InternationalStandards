/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;
using BenBurgers.InternationalStandards.Iso.Json.Iso639.Exceptions;
using System.Text.Json;

namespace BenBurgers.InternationalStandards.Iso.Json.Iso639.Alpha;

/// <summary>
/// Converts an <see cref="Iso639Code" /> from and to its Alpha-2 two-letter code or Alpha-3 three-letter code equivalent. 
/// </summary>
public sealed class Iso639AlphaJsonConverter : Iso639JsonConverterBase
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639AlphaJsonConverter" />.
    /// </summary>
    /// <param name="options">
    /// ISO 639 JSON Converter options.
    /// </param>
    public Iso639AlphaJsonConverter(Iso639JsonConverterOptions options)
        : base(options)
    {
    }

    /// <inheritdoc />
    /// <exception cref="Iso639JsonConverterException">
    /// An <see cref="Iso639JsonConverterException" /> is thrown if the Alpha code could not be read.
    /// </exception>
    public override Iso639Code Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            var alphaString = reader.GetString()!;
            if (this.Options.CaseInsensitive)
                alphaString = alphaString.ToLowerInvariant();
            return alphaString.ToIso639(this.Options.AllowDeprecated);
        }
        catch (Exception ex)
        {
            throw new Iso639JsonConverterException(ExceptionMessages.AlphaCouldNotBeRead, ex);
        }
    }

    /// <inheritdoc />
    /// <exception cref="Iso639JsonConverterException">
    /// An <see cref="Iso639JsonConverterException" /> is thrown if the Alpha code could not be written.
    /// </exception>
    public override void Write(Utf8JsonWriter writer, Iso639Code value, JsonSerializerOptions options)
    {
        try
        {
            switch (this.Options.AlphaMode)
            {
                case Iso639AlphaMode.Part1:
                    writer.WriteStringValue(value.ToPart1(this.Options.AllowDeprecated));
                    break;
                case Iso639AlphaMode.Part2T:
                    writer.WriteStringValue(value.ToPart2(Iso639Part2Type.Terminological, this.Options.AllowDeprecated));
                    break;
                case Iso639AlphaMode.Part2B:
                    writer.WriteStringValue(value.ToPart2(Iso639Part2Type.Bibliographic, this.Options.AllowDeprecated));
                    break;
                case Iso639AlphaMode.Part3:
                default:
                    writer.WriteStringValue(value.ToPart3(this.Options.AllowDeprecated));
                    break;
            }
        }
        catch (Exception ex)
        {
            throw new Iso639JsonConverterException(ExceptionMessages.AlphaCouldNotBeWritten, ex);
        }
    }
}
