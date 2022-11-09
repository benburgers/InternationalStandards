/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166;
using System.Text.Json.Serialization;

namespace BenBurgers.InternationalStandards.Iso.Json.Iso3166;

/// <summary>
/// A base class for ISO 3166 JSON Converters.
/// </summary>
public abstract class Iso3166JsonConverterBase : JsonConverter<Iso3166Code>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166JsonConverterBase" />.
    /// </summary>
    /// <param name="options">
    /// The ISO 3166 JSON Converter options.
    /// </param>
    protected Iso3166JsonConverterBase(Iso3166JsonConverterOptions options)
    {
        this.Options = options;
    }

    /// <summary>
    /// Gets the ISO 3166 JSON Converter options.
    /// </summary>
    protected Iso3166JsonConverterOptions Options { get; }
}
