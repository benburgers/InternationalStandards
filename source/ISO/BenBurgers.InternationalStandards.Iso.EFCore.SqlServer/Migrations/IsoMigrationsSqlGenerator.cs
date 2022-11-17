/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Update;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations;

/// <summary>
/// A service for generating <see cref="MigrationCommand" /> objects that can then be executed or scripted from a list of <see cref="MigrationOperation" />s.
/// </summary>
internal sealed class IsoMigrationsSqlGenerator : SqlServerMigrationsSqlGenerator
{
    /// <summary>
    /// Initializes a new instance of <see cref="IsoMigrationsSqlGenerator" />.
    /// </summary>
    /// <param name="dependencies">
    /// The dependencies.
    /// </param>
    /// <param name="commandBatchPreparer">
    /// The command batch preparer.
    /// </param>
    public IsoMigrationsSqlGenerator(
        MigrationsSqlGeneratorDependencies dependencies,
        ICommandBatchPreparer commandBatchPreparer)
        : base(dependencies, commandBatchPreparer)
    {
    }

    /// <inheritdoc />
    public override IReadOnlyList<MigrationCommand> Generate(
        IReadOnlyList<MigrationOperation> operations,
        IModel? model = null,
        MigrationsSqlGenerationOptions options = MigrationsSqlGenerationOptions.Default)
    {
        // Execute internal.
        model = model ?? this.Dependencies.CurrentContext.Context.Model;
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
        var permissionCommandBuilder = this.Dependencies.CommandBuilderFactory.Create();
        foreach (var operation in operationsSchemaPermissions)
        {
            var verb = operation.Verb.ToString().ToUpperInvariant();
            var commandName = operation.CommandName.ToString().ToUpperInvariant();
            var schemaName = operation.SchemaName;
            var databasePrincipal = operation.DatabasePrincipal;
            permissionCommandBuilder
                .Append($"{verb} {commandName} ON SCHEMA :: {schemaName} TO {databasePrincipal}")
                .AppendLine();
        }
        commands.Add(new MigrationCommand(permissionCommandBuilder.Build(), this.Dependencies.CurrentContext.Context, this.Dependencies.Logger));

        return commands;
    }
}
