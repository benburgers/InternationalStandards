/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso;

/// <summary>
/// Extension methods for <see cref="GlobalizedString" />.
/// </summary>
public static class GlobalizedStringExtensions
{
    /// <summary>
    /// Converts the <paramref name="values" /> to a <see cref="GlobalizedString" />.
    /// </summary>
    /// <param name="values">The values to convert.</param>
    /// <param name="languageDefault">If specified, the default language for which to return a localized value if a specified key does not have an associated value.</param>
    /// <returns>The globalized string.</returns>
    public static GlobalizedString ToGlobalizedString(
        this IDictionary<Iso639Code, string> values,
        Iso639Code? languageDefault = null)
        => new(values, languageDefault);
}