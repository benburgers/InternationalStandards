/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;
using BenBurgers.InternationalStandards.Iso.Json.Iso639.Alpha;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BenBurgers.InternationalStandards.Iso.Json.Iso639;

/// <summary>
/// A factory that creates a JSON converter for <see cref="Iso639Code" /> values.
/// </summary>
public class Iso639JsonConverterFactory : JsonConverterFactory
{
    private static readonly IReadOnlyDictionary<Type, Type> JsonConverterMap =
        new Dictionary<Type, Type>()
        {
            { typeof(string), typeof(Iso639AlphaJsonConverter) }
        };
    private readonly Iso639JsonConverterOptions options;

    /// <summary>
    /// Initializes a new instance of <see cref="Iso639JsonConverterFactory" />.
    /// </summary>
    /// <param name="options">
    /// The JSON convert options for ISO 639.
    /// </param>
    public Iso639JsonConverterFactory(Iso639JsonConverterOptions options)
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
