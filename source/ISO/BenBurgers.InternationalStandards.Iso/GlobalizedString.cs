/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;
using BenBurgers.InternationalStandards.Iso.Iso639.Comparers;
using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.InternationalStandards.Iso;

/// <summary>
/// A globalized string.
/// </summary>
public sealed partial class GlobalizedString : IReadOnlyDictionary<Iso639Code, string?>
{
    private readonly ImmutableSortedDictionary<Iso639Code, string> innerDictionary;

    /// <summary>
    /// Initializes a new (empty) instance of <see cref="GlobalizedString" />.
    /// </summary>
    public GlobalizedString()
        : this(new SortedDictionary<Iso639Code, string>(new Iso639CodeAlphaPart1Comparer()), null)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="GlobalizedString" />.
    /// </summary>
    /// <param name="languageDefault">The default language if a requested language does not have a value.</param>
    public GlobalizedString(Iso639Code? languageDefault)
        : this(new SortedDictionary<Iso639Code, string>(new Iso639CodeAlphaPart1Comparer()), languageDefault)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="GlobalizedString" />.
    /// </summary>
    /// <param name="values">The values of the globalized string.</param>
    /// <param name="languageDefault">The default language if a requested language does not have a value.</param>
    public GlobalizedString(
        IDictionary<Iso639Code, string> values,
        Iso639Code? languageDefault = null)
    {
        this.LanguageDefault = languageDefault;
        this.innerDictionary =
            values is ImmutableSortedDictionary<Iso639Code, string> { KeyComparer: { } comparer } sortedDictionary
            && comparer is Iso639CodeAlphaPart1Comparer
                ? sortedDictionary
                : new SortedDictionary<Iso639Code, string>(
                    values,
                    new Iso639CodeAlphaPart1Comparer())
                .ToImmutableSortedDictionary();
    }

    /// <summary>
    /// Gets the localized string for the specified language <paramref name="key" />.
    /// If the key does not have an associated value and a default language is defined, the default language key is used instead.
    /// </summary>
    /// <param name="key">The key of the language for which to attempt to retrieve a localized string.</param>
    /// <returns>The localized string, or <see langword="null" /> if not found.</returns>
    public string? this[Iso639Code key] =>
        this.innerDictionary.TryGetValue(key, out var value)
            ? value
            : this.LanguageDefault is { } languageDefault
                ? this.innerDictionary.TryGetValue(languageDefault, out var valueDefault)
                    ? valueDefault
                    : null
                : null;

    /// <inheritdoc />
    public IEnumerable<Iso639Code> Keys => this.innerDictionary.Keys;

    /// <inheritdoc />
    public IEnumerable<string?> Values => this.innerDictionary.Values;

    /// <inheritdoc />
    public int Count => this.innerDictionary.Count;

    /// <summary>
    /// Gets the default language for which a value will be retrieved if a requested language does not have a value.
    /// </summary>
    public Iso639Code? LanguageDefault { get; }

    /// <inheritdoc />
    public bool ContainsKey(Iso639Code key) =>
        this.innerDictionary.ContainsKey(key);

    /// <inheritdoc />
    public IEnumerator<KeyValuePair<Iso639Code, string?>> GetEnumerator() =>
        this.innerDictionary.GetEnumerator();

    /// <summary>
    /// Attempts to retrieve a localized string for the specified <paramref name="key" />.
    /// If the key does not have an associated value and a default language is specified, the default language will be attempted.
    /// </summary>
    /// <param name="key">The requested language for which to retrieve the localized string.</param>
    /// <param name="value">The localized string value, if found.</param>
    /// <returns>A value that indicates whether the localized string value was found, or a default value was found.</returns>
    public bool TryGetValue(Iso639Code key, [MaybeNullWhen(false)] out string? value) =>
        this.innerDictionary.TryGetValue(key, out value)
            ? true
            : this.LanguageDefault is { } languageDefault
                ? this.innerDictionary.TryGetValue(languageDefault, out value)
                : false;

    /// <summary>
    /// Returns the string value for the default language.
    /// </summary>
    /// <returns>The string value for the default language.</returns>
    public override string ToString() =>
        this.innerDictionary.TryGetValue(this.LanguageDefault!.Value, out var value)
            ? value
            : string.Empty;

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();
}
