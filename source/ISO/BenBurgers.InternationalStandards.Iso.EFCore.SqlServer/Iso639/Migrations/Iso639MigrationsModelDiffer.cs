/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Exceptions;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Infrastructure;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations.Operations;
using BenBurgers.InternationalStandards.Iso.Iso639;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso639.Migrations;

/// <summary>
/// A service for finding differences between two <see cref="IRelationalModel" />s and transforming those differences into <see cref="MigrationOperation" />s that can be used to update the database.
/// </summary>
[SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "Enhancement of EF Core API.")]
internal sealed class Iso639MigrationsModelDiffer : MigrationsModelDiffer
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639MigrationsModelDiffer" />.
    /// </summary>
    /// <param name="typeMappingSource">
    /// The type mapping source.
    /// </param>
    /// <param name="migrationsAnnotationProvider">
    /// The migrations annotation provider.
    /// </param>
    /// <param name="rowIdentityMapFactory">
    /// The row identity map factory.
    /// </param>
    /// <param name="commandBatchPreparerDependencies">
    /// The command batch preparer dependencies.
    /// </param>
    public Iso639MigrationsModelDiffer(
        IRelationalTypeMappingSource typeMappingSource,
        IMigrationsAnnotationProvider migrationsAnnotationProvider,
        IRowIdentityMapFactory rowIdentityMapFactory,
        CommandBatchPreparerDependencies commandBatchPreparerDependencies)
        : base(typeMappingSource, migrationsAnnotationProvider, rowIdentityMapFactory, commandBatchPreparerDependencies)
    {
    }

    public override IReadOnlyList<MigrationOperation> GetDifferences(IRelationalModel? source, IRelationalModel? target)
    {
        // Execute internal.
        var migrationOperations =
            base
                .GetDifferences(source, target)
                .ToList();

        // Add additional operations for new table.
        var extension =
            this
                .CommandBatchPreparerDependencies
                .Options
                .FindExtension<IsoDbContextOptionsExtension>();
        if (extension is null)
            throw new IsoDbContextOptionsExtensionNotConfiguredException();
        var schemaName = extension.SchemaName;
        var sourceTable = source?.FindTable(nameof(Iso639Code), schemaName);
        var targetTable = target?.FindTable(nameof(Iso639Code), schemaName);
        if (sourceTable is null && targetTable is not null)
        {
            migrationOperations.AddRange(SqlSchemaMigrationOperations.GetReadOnly(schemaName));
        }

        return migrationOperations;
    }

    /// <inheritdoc />
    public override bool HasDifferences(IRelationalModel? source, IRelationalModel? target)
    {
        return this.GetDifferences(source, target).Any();
    }
}
