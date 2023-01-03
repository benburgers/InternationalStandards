/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso;

/// <summary>
/// An attribute that specifies a localized name.
/// </summary>
internal interface ILocalizedNameAttribute
{
    /// <summary>
    /// Gets the ISO 639 code of the language of the localized name.
    /// </summary>
    internal Iso639Code Iso639Code { get; }

    /// <summary>
    /// Gets the value of the localized name in the specified language.
    /// </summary>
    internal string Name { get; }
}
