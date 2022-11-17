/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations.Operations;

/// <summary>
/// Provides migration operations for SQL Schemas.
/// </summary>
internal static class SqlSchemaMigrationOperations
{
    private const string Public = "public";

    /// <summary>
    /// Gets the migration operations that are necessary to make tables in SQL Server Schema <paramref name="schemaName" /> read-only to public SQL Server users.
    /// </summary>
    /// <param name="schemaName">
    /// The name of the SQL Server Schema.
    /// </param>
    /// <returns>
    /// A list of <see cref="MigrationOperation" /> that make tables in SQL Server Schema <paramref name="schemaName" /> read-only to public SQL Server users.
    /// </returns>
    internal static IReadOnlyList<MigrationOperation> GetReadOnly(string schemaName)
    {
        return new MigrationOperation[]
            {
                new SqlSchemaPermissionMigrationOperation(
                    SqlPermissionVerb.Deny,
                    SqlCommandName.Delete,
                    schemaName,
                    Public),
                new SqlSchemaPermissionMigrationOperation(
                    SqlPermissionVerb.Deny,
                    SqlCommandName.Insert,
                    schemaName,
                    Public),
                new SqlSchemaPermissionMigrationOperation(
                    SqlPermissionVerb.Deny,
                    SqlCommandName.Update,
                    schemaName,
                    Public)
            };
    }
}
