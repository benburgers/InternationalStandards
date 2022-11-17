/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using System.Diagnostics;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations.Operations;

/// <summary>
/// A SQL Permission Verb.
/// </summary>
internal enum SqlPermissionVerb
{
    /// <summary>
    /// DENY
    /// </summary>
    [DebuggerDisplay("DENY")]
    Deny,

    /// <summary>
    /// GRANT
    /// </summary>
    [DebuggerDisplay("GRANT")]
    Grant,

    /// <summary>
    /// REVOKE
    /// </summary>
    [DebuggerDisplay("REVOKE")]
    Revoke,
}