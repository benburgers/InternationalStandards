/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Diagnostics;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations.Operations;

/// <summary>
/// A migration operation that applies a permission to a database schema.
/// </summary>
[DebuggerDisplay("{Verb} {CommandName} ON SCHEMA {SchemaName} TO {DatabasePrincipal}")]
internal class SqlSchemaPermissionMigrationOperation : MigrationOperation
{
    /// <summary>
    /// Initializes a new instance of <see cref="SqlSchemaPermissionMigrationOperation" />.
    /// </summary>
    /// <param name="verb">
    /// The permission verb. (GRANT/DENY)
    /// </param>
    /// <param name="commandName">
    /// The SQL command name for which the permission is granted or denied.
    /// </param>
    /// <param name="schemaName">
    /// The name of the SQL schema to which the permission is granted or denied.
    /// </param>
    /// <param name="databasePrincipal">
    /// The name of the database principal to whom/what the permission applies.
    /// </param>
    internal SqlSchemaPermissionMigrationOperation(
        SqlPermissionVerb verb,
        SqlCommandName commandName,
        string schemaName,
        string databasePrincipal)
    {
        this.Verb = verb;
        this.CommandName = commandName;
        this.SchemaName = schemaName;
        this.DatabasePrincipal = databasePrincipal;
    }

    /// <summary>
    /// Gets the permission verb. (GRANT/DENY)
    /// </summary>
    internal SqlPermissionVerb Verb { get; }

    /// <summary>
    /// Gets the SQL command name for which the permission is granted or denied.
    /// </summary>
    internal SqlCommandName CommandName { get; }

    /// <summary>
    /// Gets the name of the SQL schema to which the permission is granted or denied.
    /// </summary>
    internal string SchemaName { get; }

    /// <summary>
    /// Gets the database principal to whom/what the permission applies.
    /// </summary>
    internal string DatabasePrincipal { get; }
}
