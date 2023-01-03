/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639;

/// <summary>
/// The ISO 639 Scope.
/// </summary>
[Flags]
public enum Iso639Scope
{
    /// <summary>
    /// None.
    /// </summary>
    /// <remarks>
    /// This value may be used in queries but cannot be assigned.
    /// </remarks>
    None =
        0b0000_0000,

    /// <summary>
    /// A collective language.
    /// </summary>
    Collective =
        0b0000_0001,

    /// <summary>
    /// An individual language.
    /// </summary>
    Individual =
        0b0000_0010,

    /// <summary>
    /// A local language.
    /// </summary>
    Local =
        0b0000_0100,

    /// <summary>
    /// A macrolanguage.
    /// </summary>
    Macrolanguage =
        0b0000_1000,

    /// <summary>
    /// A special language.
    /// </summary>
    Special =
        0b0001_0000
}
