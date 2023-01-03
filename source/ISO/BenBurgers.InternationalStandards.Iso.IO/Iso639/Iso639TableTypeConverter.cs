/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;
using System.ComponentModel;
using System.Globalization;

namespace BenBurgers.InternationalStandards.Iso.IO.Iso639;

/// <summary>
/// A type converter for ISO 639 tables.
/// </summary>
public sealed class Iso639TableTypeConverter : TypeConverter
{
    private static readonly IReadOnlyDictionary<Iso639Scope, string> Scopes =
        new Dictionary<Iso639Scope, string>
        {
            { Iso639Scope.Individual, "I" },
            { Iso639Scope.Macrolanguage, "M" },
            { Iso639Scope.Special, "S" }
        };

    private static readonly IReadOnlyDictionary<Iso639Status, string> Statuses =
        new Dictionary<Iso639Status, string>
        {
            { Iso639Status.Active, "A" },
            { Iso639Status.Retired, "R" }
        };

    private static readonly IReadOnlyDictionary<Iso639LanguageType, string> LanguageTypes =
        new Dictionary<Iso639LanguageType, string>
        {
            { Iso639LanguageType.Ancient, "A" },
            { Iso639LanguageType.Constructed, "C" },
            { Iso639LanguageType.Extinct, "E" },
            { Iso639LanguageType.Historical, "H" },
            { Iso639LanguageType.Living, "L" },
            { Iso639LanguageType.Special, "S" }
        };

    private static readonly IReadOnlyDictionary<Type, Func<string?, CultureInfo?, object?>> DestinationConverters =
        new Dictionary<Type, Func<string?, CultureInfo?, object?>>
        {
            { typeof(Alpha2), (s, _) => s == null || string.IsNullOrWhiteSpace(s) ? null : new Alpha2(s) },
            { typeof(Alpha3), (s, _) => s == null || string.IsNullOrWhiteSpace(s) ? null : new Alpha3(s) },
            { typeof(DateOnly), (s, c) => s == null ? null : DateOnly.Parse(s, c) },
            { typeof(Iso639LanguageType), (s, _) => LanguageTypes.FirstOrDefault(kvp => kvp.Value == s).Key },
            { typeof(Iso639Scope), (s, _) => Scopes.FirstOrDefault(kvp => kvp.Value == s).Key },
            { typeof(Iso639Status), (s, _) => Statuses.FirstOrDefault(kvp => kvp.Value == s).Key },
            { typeof(string), (s, _) => s }
        };

    private static readonly IReadOnlyDictionary<Type, Func<object?, CultureInfo?, string?>> SourceConverters =
        new Dictionary<Type, Func<object?, CultureInfo?, string?>>
        {
            { typeof(Alpha2), (o, _) => o is Alpha2 { } a ? a.Value : string.Empty },
            { typeof(Alpha3), (o, _) => o is Alpha3 { } a ? a.Value : string.Empty },
            { typeof(DateOnly), (o, c) => o is DateOnly { } d ? d.ToString(c) : string.Empty },
            { typeof(Iso639LanguageType), (o, _) => o is Iso639LanguageType { } l ? LanguageTypes[l] : string.Empty },
            { typeof(Iso639Scope), (o, _) => o is Iso639Scope { } s ? Scopes[s] : string.Empty },
            { typeof(Iso639Status), (o, _) => o is Iso639Status { } s ? Statuses[s] : string.Empty },
            { typeof(string), (o, _) => o as string }
        };

    /// <inheritdoc />
    public override bool CanConvertFrom(
        ITypeDescriptorContext? context,
        Type sourceType)
    {
        return SourceConverters.ContainsKey(sourceType);
    }

    /// <inheritdoc />
    public override bool CanConvertTo(
        ITypeDescriptorContext? context,
        Type? destinationType)
    {
        return
            destinationType is { }
                && DestinationConverters.ContainsKey(destinationType);
    }

    /// <inheritdoc />
    public override object? ConvertFrom(
        ITypeDescriptorContext? context,
        CultureInfo? culture,
        object value)
    {
        return
            SourceConverters.TryGetValue(value.GetType(), out var converter)
                ? converter(value, culture)
                : null;
    }

    /// <inheritdoc />
    public override object? ConvertTo(
        ITypeDescriptorContext? context,
        CultureInfo? culture,
        object? value,
        Type destinationType)
    {
        if (value is not string { } stringValue)
            return null;
        return DestinationConverters.TryGetValue(destinationType, out var converter)
            ? converter(stringValue, culture)
            : null;
    }
}
