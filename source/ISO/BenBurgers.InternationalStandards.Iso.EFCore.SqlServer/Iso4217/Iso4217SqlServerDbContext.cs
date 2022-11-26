/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Configuration;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Exceptions;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Infrastructure;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso4217.Migrations;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso4217;

/// <summary>
/// An Entity Framework Core Database Context for ISO 4217 codes.
/// </summary>
public sealed class Iso4217SqlServerDbContext : IsoDbContext
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217SqlServerDbContext" />.
    /// </summary>
    /// <param name="isoSqlServerOptions">
    /// The configuration options for <see cref="IsoSqlServerOptions" />.
    /// </param>
    public Iso4217SqlServerDbContext(IsoSqlServerOptions isoSqlServerOptions)
        : base(isoSqlServerOptions)
    {
    }

    /// <inheritdoc />
    /// <exception cref="IsoSqlServerNotConfiguredException">
    /// An <see cref="IsoSqlServerNotConfiguredException" /> is thrown if the configuration options have not been configured properly.
    /// </exception>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var (connectionString, migrationsAssembly, enableSensitiveDataLogging, _) = this.IsoSqlServerOptions;
        if (connectionString is null)
            throw new IsoSqlServerNotConfiguredException();
        optionsBuilder
            .ReplaceService<IMigrationsModelDiffer, Iso4217MigrationsModelDiffer>()
            .ReplaceService<IMigrationsSqlGenerator, IsoMigrationsSqlGenerator>()
            .UseSqlServer(connectionString, builder =>
            {
                if (migrationsAssembly is not null)
                    builder.MigrationsAssembly(migrationsAssembly);
            })
            .EnableSensitiveDataLogging(enableSensitiveDataLogging ?? false);
        base.OnConfiguring(optionsBuilder);
    }

    /// <inheritdoc />
    /// <exception cref="IsoSqlServerNotConfiguredException">
    /// An <see cref="IsoSqlServerNotConfiguredException" /> is thrown if the configuration options have not been configured properly.
    /// </exception>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (this.IsoSqlServerOptions.SchemaName is not { } schemaName)
            throw new IsoSqlServerNotConfiguredException();
        modelBuilder.ApplyIso4217(schemaName);
        base.OnModelCreating(modelBuilder);
    }
}
