/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso.Iso3166.Attributes;

/// <summary>
/// An attribute that specifies a localized full name of an ISO 3166 country.
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
internal sealed class Iso3166FullNameAttribute : Attribute, ILocalizedNameAttribute
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166FullNameAttribute" />.
    /// </summary>
    /// <param name="iso639Code">The ISO 639 code of the language of the full name.</param>
    /// <param name="fullName">The full name of the ISO 3166 country in the specified language.</param>
    internal Iso3166FullNameAttribute(Iso639Code iso639Code, string fullName)
    {
        this.Iso639Code = iso639Code;
        this.FullName = fullName;
    }

    /// <summary>
    /// Gets the ISO 639 code of the language of the full name.
    /// </summary>
    internal Iso639Code Iso639Code { get; }

    /// <summary>
    /// Gets the full name of the ISO 3166 country in the specified language.
    /// </summary>
    internal string FullName { get; }

    Iso639Code ILocalizedNameAttribute.Iso639Code => this.Iso639Code;
    string ILocalizedNameAttribute.Name => this.FullName;
}