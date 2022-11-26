/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations;

/// <summary>
/// Extension methods for Entity Framework Core <see cref="MigrationBuilder" />.
/// </summary>
public static class MigrationBuilderExtensions
{
    /// <summary>
    /// Sets a particular permission to a particular SQL Server Schema.
    /// </summary>
    /// <param name="builder">
    /// The migration builder.
    /// </param>
    /// <param name="verb">
    /// The permission verb.
    /// </param>
    /// <param name="commandName">
    /// The SQL command.
    /// </param>
    /// <param name="schemaName">
    /// The SQL Server Schema.
    /// </param>
    /// <param name="databasePrincipal">
    /// The database principal to which to assign or from which to revoke the permission.
    /// </param>
    /// <returns>
    /// The migration builder.
    /// </returns>
    public static OperationBuilder<SqlOperation> IsoSchemaPermission(
        this MigrationBuilder builder,
        SqlPermissionVerb verb,
        SqlCommandName commandName,
        string schemaName,
        string databasePrincipal)
    {
        IsoConsole.WriteLines("Permissions migration building.");
        var sql = $"EXEC ('{verb.ToString().ToUpperInvariant()} {commandName.ToString().ToUpperInvariant()} ON SCHEMA :: {schemaName} TO {databasePrincipal}')";
        var operation = new SqlOperation { Sql = sql };
        builder.Operations.Add(operation);
        IsoConsole.WriteLines($"Permissions migration built: \"{sql}\"");
        return new OperationBuilder<SqlOperation>(operation);
    }
}
