/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Exceptions;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Infrastructure;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations.Operations;
using BenBurgers.InternationalStandards.Iso.Iso4217;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
#if NET6_0
using Microsoft.EntityFrameworkCore.Update;
#endif
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso4217.Migrations;

/// <summary>
/// A service for finding differences between two <see cref="IRelationalModel" />s and transforming those differences into <see cref="MigrationOperation" />s that can be used to update the database.
/// </summary>
[SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "Enhancement of EF Core API.")]
internal sealed class Iso4217MigrationsModelDiffer : MigrationsModelDiffer
{
#if NET6_0
    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217MigrationsModelDiffer" />.
    /// </summary>
    /// <param name="typeMappingSource">
    /// The type mapping source.
    /// </param>
    /// <param name="migrationsAnnotationProvider">
    /// The migrations annotation provider.
    /// </param>
    /// <param name="changeDetector">
    /// The change detector.
    /// </param>
    /// <param name="updateAdapterFactory">
    /// The update adapter factory.
    /// </param>
    /// <param name="commandBatchPreparerDependencies">
    /// The command batch preparer dependencies.
    /// </param>
#endif
#if NET7_0_OR_GREATER
    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217MigrationsModelDiffer" />.
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
#endif
    public Iso4217MigrationsModelDiffer(
        IRelationalTypeMappingSource typeMappingSource,
        IMigrationsAnnotationProvider migrationsAnnotationProvider,
#if NET6_0
        IChangeDetector changeDetector,
        IUpdateAdapterFactory updateAdapterFactory,
#endif
#if NET7_0_OR_GREATER
        IRowIdentityMapFactory rowIdentityMapFactory,
#endif
        CommandBatchPreparerDependencies commandBatchPreparerDependencies)
        : base(
            typeMappingSource,
            migrationsAnnotationProvider,
#if NET6_0
            changeDetector,
            updateAdapterFactory,
#endif
#if NET7_0_OR_GREATER
            rowIdentityMapFactory,
#endif
            commandBatchPreparerDependencies)
    {
    }

    /// <inheritdoc />
    /// <exception cref="IsoDbContextOptionsExtensionNotConfiguredException">
    /// An <see cref="IsoDbContextOptionsExtensionNotConfiguredException" /> is thrown if the extension for the ISO Database Context Options Extension is not configured.
    /// </exception>
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
        var sourceTable = source?.FindTable(nameof(Iso4217Code), schemaName);
        var targetTable = target?.FindTable(nameof(Iso4217Code), schemaName);
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
