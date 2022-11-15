/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;
using System.Text.Json.Serialization;

namespace BenBurgers.InternationalStandards.Iso.Json.Iso4217;

/// <summary>
/// A base class for ISO 4217 JSON Converters.
/// </summary>
public abstract class Iso4217JsonConverterBase : JsonConverter<Iso4217Code>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217JsonConverterBase" />.
    /// </summary>
    /// <param name="options">
    /// The ISO 4217 JSON Converter options.
    /// </param>
    protected Iso4217JsonConverterBase(Iso4217JsonConverterOptions options)
    {
        this.Options = options;
    }

    /// <summary>
    /// Gets the ISO 4217 JSON Converter options.
    /// </summary>
    protected Iso4217JsonConverterOptions Options { get; }
}
