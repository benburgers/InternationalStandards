/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166;
using BenBurgers.InternationalStandards.Iso.Json.Iso3166.Alpha;
using BenBurgers.InternationalStandards.Iso.Json.Iso3166.Numeric;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BenBurgers.InternationalStandards.Iso.Json.Iso3166;

/// <summary>
/// A factory that creates a JSON converter for <see cref="Iso3166Code" /> values.
/// </summary>
public class Iso3166JsonConverterFactory : JsonConverterFactory
{
    private static readonly IReadOnlyDictionary<Type, Type> JsonConverterMap =
        new Dictionary<Type, Type>
        {
            { typeof(string), typeof(Iso3166AlphaJsonConverter) },
            { typeof(int), typeof(Iso3166NumericJsonConverter) }
        };
    private readonly Iso3166JsonConverterOptions options;

    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166JsonConverterFactory" />.
    /// </summary>
    /// <param name="options">
    /// The JSON converter options for ISO 3166.
    /// </param>
    public Iso3166JsonConverterFactory(Iso3166JsonConverterOptions options)
    {
        this.options = options;
    }

    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert)
    {
        return JsonConverterMap.ContainsKey(typeToConvert);
    }

    /// <inheritdoc />
    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (JsonConverterMap.TryGetValue(typeToConvert, out var jsonConverterType))
            return (JsonConverter)Activator.CreateInstance(jsonConverterType, this.options)!;
        return null;
    }
}
