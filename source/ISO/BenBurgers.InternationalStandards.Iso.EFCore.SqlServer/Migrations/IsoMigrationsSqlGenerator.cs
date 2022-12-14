/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
#if NET7_0_OR_GREATER
using Microsoft.EntityFrameworkCore.Update;
#endif

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations;

/// <summary>
/// A service for generating <see cref="MigrationCommand" /> objects that can then be executed or scripted from a list of <see cref="MigrationOperation" />s.
/// </summary>
internal sealed class IsoMigrationsSqlGenerator : SqlServerMigrationsSqlGenerator
{
#if NET6_0
    /// <summary>
    /// Initializes a new instance of <see cref="IsoMigrationsSqlGenerator" />.
    /// </summary>
    /// <param name="dependencies">
    /// The dependencies.
    /// </param>
    /// <param name="relationAnnotationProvider">
    /// The relation annotation provider.
    /// </param>
#endif
#if NET7_0_OR_GREATER
    /// <summary>
    /// Initializes a new instance of <see cref="IsoMigrationsSqlGenerator" />.
    /// </summary>
    /// <param name="dependencies">
    /// The dependencies.
    /// </param>
    /// <param name="commandBatchPreparer">
    /// The command batch preparer.
    /// </param>
#endif
    public IsoMigrationsSqlGenerator(
        MigrationsSqlGeneratorDependencies dependencies,
#if NET6_0
        IRelationalAnnotationProvider relationAnnotationProvider)
#endif
#if NET7_0_OR_GREATER
        ICommandBatchPreparer commandBatchPreparer)
#endif
        : base(
            dependencies,
#if NET6_0
            relationAnnotationProvider)
#endif
#if NET7_0_OR_GREATER
            commandBatchPreparer)
#endif
    {
    }

    /// <inheritdoc />
    public override IReadOnlyList<MigrationCommand> Generate(
        IReadOnlyList<MigrationOperation> operations,
        IModel? model = null,
        MigrationsSqlGenerationOptions options = MigrationsSqlGenerationOptions.Default)
    {
        // Execute internal.
        model ??= this.Dependencies.CurrentContext.Context.Model;
        var operationsSchemaPermissions =
            operations
                .OfType<SqlSchemaPermissionMigrationOperation>()
                .ToArray();
        var operationsBase =
            operations
                .Except(operationsSchemaPermissions)
                .ToArray();
        var commands = base.Generate(operationsBase, model, options).ToList();

        // Add additional commands.
        foreach (var operation in operationsSchemaPermissions)
        {
            var permissionCommandBuilder = this.Dependencies.CommandBuilderFactory.Create();
            var verb = operation.Verb.ToString().ToUpperInvariant();
            var commandName = operation.CommandName.ToString().ToUpperInvariant();
            var schemaName = operation.SchemaName;
            var databasePrincipal = operation.DatabasePrincipal;
            IsoConsole.WriteLines($"Generating SQL for permission operation. ({verb}, {commandName}, {schemaName}, {databasePrincipal})");
            permissionCommandBuilder
                .Append("EXEC ('")
                .Append($"{verb} {commandName} ON SCHEMA :: {schemaName} TO {databasePrincipal}")
                .Append("')");
            commands.Add(new MigrationCommand(permissionCommandBuilder.Build(), this.Dependencies.CurrentContext.Context, this.Dependencies.Logger));
        }

        return commands;
    }
}
