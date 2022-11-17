/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Exceptions;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Infrastructure;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations.Operations;
using BenBurgers.InternationalStandards.Iso.Iso3166;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso3166.Migrations;

/// <summary>
/// A service for finding differences between two <see cref="IRelationalModel" />s and transforming those differences into <see cref="MigrationOperation" />s that can be used to update the database.
/// </summary>
[SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "Enhancement of EF Core API.")]
internal sealed class Iso3166MigrationsModelDiffer : MigrationsModelDiffer
{
    private const string Public = "public";

    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166MigrationsModelDiffer" />.
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
    public Iso3166MigrationsModelDiffer(
        IRelationalTypeMappingSource typeMappingSource,
        IMigrationsAnnotationProvider migrationsAnnotationProvider,
        IRowIdentityMapFactory rowIdentityMapFactory,
        CommandBatchPreparerDependencies commandBatchPreparerDependencies)
        : base(typeMappingSource, migrationsAnnotationProvider, rowIdentityMapFactory, commandBatchPreparerDependencies)
    {
    }

    /// <inheritdoc />
    /// <exception cref="IsoDbContextOptionsExtensionNotConfiguredException">
    /// An <see cref="IsoDbContextOptionsExtensionNotConfiguredException" /> is thrown if the extension for the ISO Database Context Options is not configured.
    /// </exception>
    public override IReadOnlyList<MigrationOperation> GetDifferences(IRelationalModel? source, IRelationalModel? target)
    {
        // Execute internal.
        var migrations =
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
        var sourceTable = source?.FindTable(nameof(Iso3166Code), schemaName);
        var targetTable = target?.FindTable(nameof(Iso3166Code), schemaName);
        if (sourceTable is null && targetTable is not null)
        {
            migrations.AddRange(SqlSchemaMigrationOperations.GetReadOnly(schemaName));
        }

        return migrations;
    }

    /// <inheritdoc />
    public override bool HasDifferences(IRelationalModel? source, IRelationalModel? target)
    {
        return this.GetDifferences(source, target).Any();
    }
}
