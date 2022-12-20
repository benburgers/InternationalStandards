/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;
using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.InternationalStandards.Iso.Iso3166.Attributes;

/// <summary>
/// An attribute that specifies an ISO 3166 country's short name in upper case in a particular language.
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
internal sealed class Iso3166ShortNameUpperCaseAttribute : Attribute, ILocalizedNameAttribute
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166ShortNameUpperCaseAttribute" />.
    /// </summary>
    /// <param name="iso639Code">The ISO 639 code of the language.</param>
    /// <param name="shortNameUpperCase">The short name in upper case in the specified language.</param>
    internal Iso3166ShortNameUpperCaseAttribute(Iso639Code iso639Code, string shortNameUpperCase)
    {
        this.Iso639Code = iso639Code;
        this.ShortNameUpperCase = shortNameUpperCase;
    }

    /// <summary>
    /// Gets the ISO 639 code of the language.
    /// </summary>
    internal Iso639Code Iso639Code { get; }

    /// <summary>
    /// Gets the short name in upper case in the specified language.
    /// </summary>
    internal string ShortNameUpperCase { get; }

    Iso639Code ILocalizedNameAttribute.Iso639Code => this.Iso639Code;
    string ILocalizedNameAttribute.Name => this.ShortNameUpperCase;

    /// <inheritdoc />
    public override bool Equals([NotNullWhen(true)] object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            Iso3166ShortNameUpperCaseAttribute other => this.Equals(other),
            _ => false
        };

    private bool Equals(Iso3166ShortNameUpperCaseAttribute other) =>
        this.Iso639Code == other.Iso639Code
        && this.ShortNameUpperCase == other.ShortNameUpperCase;

    /// <inheritdoc />
    public override int GetHashCode() =>
        HashCode.Combine(this.Iso639Code, this.ShortNameUpperCase);
}
