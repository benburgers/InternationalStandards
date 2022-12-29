/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso.Iso3166.Comparers;

/// <summary>
/// Compares <see cref="Iso3166Code" /> based on their localized upper case short name and returns the difference.
/// </summary>
public sealed class Iso3166CodeShortNameUpperCaseComparer : IComparer<Iso3166Code>
{
    private readonly Iso639Code language;
    private readonly Iso639Code? languageDefault;

    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166CodeShortNameUpperCaseComparer" />.
    /// </summary>
    /// <param name="language">The language of the upper case short name.</param>
    /// <param name="languageDefault">The default language of the upper case short name.</param>
    public Iso3166CodeShortNameUpperCaseComparer(Iso639Code language, Iso639Code? languageDefault = null)
    {
        this.language = language;
        this.languageDefault = languageDefault;
    }

    /// <inheritdoc />
    public int Compare(Iso3166Code x, Iso3166Code y) =>
        x.GetShortNameUpperCase(this.languageDefault)[this.language]?.CompareTo(y.GetShortNameUpperCase(this.languageDefault)[this.language]) ?? int.MaxValue;
}
