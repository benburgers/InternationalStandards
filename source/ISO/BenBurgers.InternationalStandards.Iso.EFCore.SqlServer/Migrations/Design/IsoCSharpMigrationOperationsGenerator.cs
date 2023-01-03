/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations.Design;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations.Design;

/// <summary>
/// Generates C# code for migrations concerning ISO standards.
/// </summary>
internal sealed class IsoCSharpMigrationOperationsGenerator : CSharpMigrationOperationGenerator
{
    /// <summary>
    /// Initializes a new instance of <see cref="IsoCSharpMigrationOperationsGenerator" />.
    /// </summary>
    /// <param name="dependencies">
    /// The dependencies.
    /// </param>
    public IsoCSharpMigrationOperationsGenerator(CSharpMigrationOperationGeneratorDependencies dependencies)
        : base(dependencies)
    {
    }

    /// <inheritdoc />
    protected override void Generate(MigrationOperation operation, IndentedStringBuilder builder)
    {
        switch (operation)
        {
            case SqlSchemaPermissionMigrationOperation schemaPermissionOperation:
                Generate(schemaPermissionOperation, builder);
                break;
            default:
                base.Generate(operation, builder);
                break;
        }

    }

    private static void Generate(SqlSchemaPermissionMigrationOperation operation, IndentedStringBuilder builder)
    {
        var verbTypeName = typeof(SqlPermissionVerb).FullName;
        var commandTypeName = typeof(SqlCommandName).FullName;
        builder
            .Append(".IsoSchemaPermission(")
            .Append($"{verbTypeName}.{operation.Verb}")
            .Append($", {commandTypeName}.{operation.CommandName}")
            .Append($", \"{operation.SchemaName}\"")
            .Append($", \"{operation.DatabasePrincipal}\"")
            .Append(")");
    }
}
