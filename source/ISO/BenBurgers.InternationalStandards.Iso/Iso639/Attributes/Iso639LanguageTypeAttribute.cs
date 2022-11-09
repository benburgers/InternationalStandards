/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639.Attributes;

/// <summary>
/// An attribute that describes the ISO 639 language type.
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
internal sealed class Iso639LanguageTypeAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639LanguageTypeAttribute" />.
    /// </summary>
    /// <param name="languageType">
    /// The ISO 639 language type.
    /// </param>
    internal Iso639LanguageTypeAttribute(Iso639LanguageType languageType)
    {
        this.LanguageType = languageType;
    }

    /// <summary>
    /// Gets the ISO 639 language type.
    /// </summary>
    internal Iso639LanguageType LanguageType { get; }
}
