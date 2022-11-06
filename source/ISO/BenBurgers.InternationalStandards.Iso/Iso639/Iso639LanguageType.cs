/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639;

/// <summary>
/// The ISO 639 Language Type.
/// </summary>
/// <remarks>
/// As provided by <a href="https://iso639-3.sil.org/code_tables/639/data">ISO 639 Code Tables</a>.
/// </remarks>
[Flags]
public enum Iso639LanguageType
{
    /// <summary>
    /// None.
    /// </summary>
    /// <remarks>
    /// This value may be used in queries, but cannot be assigned.
    /// </remarks>
    None =
        0b0000_0000_0000_0000,

    /// <summary>
    /// Ancient language.
    /// </summary>
    Ancient =
        0b0000_0000_0000_0001,

    /// <summary>
    /// Constructed language.
    /// </summary>
    Constructed =
        0b0000_0000_0000_0010,

    /// <summary>
    /// Extinct language.
    /// </summary>
    Extinct =
        0b0000_0000_0000_0100,

    /// <summary>
    /// Genetic language.
    /// </summary>
    Genetic =
        0b0000_0000_0000_1000,

    /// <summary>
    /// Genetic, Ancient language.
    /// </summary>
    GeneticAncient =
        0b0000_0000_0001_0000,

    /// <summary>
    /// Genetic-like language.
    /// </summary>
    GeneticLike =
        0b0000_0000_0010_0000,

    /// <summary>
    /// Geographic language.
    /// </summary>
    Geographic =
        0b0000_0000_0100_0000,

    /// <summary>
    /// Historical language.
    /// </summary>
    Historical =
        0b0000_0000_1000_0000,

    /// <summary>
    /// Living language.
    /// </summary>
    Living =
        0b0000_0001_0000_0000,

    /// <summary>
    /// Special language.
    /// </summary>
    Special =
        0b0000_0010_0000_0000
}
