/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations.Operations;

/// <summary>
/// The name of a SQL command.
/// </summary>
internal enum SqlCommandName
{
    /// <summary>
    /// DELETE
    /// </summary>
    Delete,

    /// <summary>
    /// INSERT
    /// </summary>
    Insert,

    /// <summary>
    /// SELECT
    /// </summary>
    Select,

    /// <summary>
    /// UPDATE
    /// </summary>
    Update
}
