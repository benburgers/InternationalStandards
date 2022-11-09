/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;
using System.Text.Json.Serialization;

namespace BenBurgers.InternationalStandards.Iso.Json.Iso639;

/// <summary>
/// A base class for ISO 639 JSON Converters.
/// </summary>
public abstract class Iso639JsonConverterBase : JsonConverter<Iso639Code>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639JsonConverterBase" />.
    /// </summary>
    /// <param name="options">
    /// The ISO 639 JSON Converter options.
    /// </param>
    protected Iso639JsonConverterBase(Iso639JsonConverterOptions options)
    {
        this.Options = options;
    }

    /// <summary>
    /// Gets the ISO 639 JSON Converter options.
    /// </summary>
    protected Iso639JsonConverterOptions Options { get; }
}
