/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso3166;

/// <summary>
/// The status of an <see cref="Iso3166Code" />.
/// </summary>
public enum Iso3166Status
{
    /// <summary>
    /// The code has been exceptionally reserved.
    /// </summary>
    ExceptionallyReserved,

    /// <summary>
    /// The code has been formerly used.
    /// </summary>
    FormerlyUsed,

    /// <summary>
    /// The code has indeterminately been reserved.
    /// </summary>
    IndeterminatelyReserved,

    /// <summary>
    /// The code has been officially assigned.
    /// </summary>
    OfficiallyAssigned,

    /// <summary>
    /// The code has been transitionally reserved.
    /// </summary>
    TransitionallyReserved,

    /// <summary>
    /// The code is unassigned.
    /// </summary>
    Unassigned
}
