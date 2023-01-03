/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */


using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso.Iso3166.Attributes;

/// <summary>
/// An attribute that specifies an ISO 3166 country's short name in a particular language.
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
internal sealed class Iso3166ShortNameAttribute : Attribute, ILocalizedNameAttribute
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166ShortNameAttribute" />.
    /// </summary>
    /// <param name="iso639Code">The ISO 639 code of the language of the short name.</param>
    /// <param name="shortName">The short name of the ISO 3166 country in the specified language.</param>
    internal Iso3166ShortNameAttribute(Iso639Code iso639Code, string shortName)
    {
        this.Iso639Code = iso639Code;
        this.ShortName = shortName;
    }

    /// <summary>
    /// Gets the ISO 639 code of the language of the short name.
    /// </summary>
    internal Iso639Code Iso639Code { get; }

    /// <summary>
    /// Gets the short name of the ISO 3166 country in the specified language.
    /// </summary>
    internal string ShortName { get; }

    Iso639Code ILocalizedNameAttribute.Iso639Code => this.Iso639Code;
    string ILocalizedNameAttribute.Name => this.ShortName;
}