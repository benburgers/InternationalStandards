/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Configuration;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Exceptions;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Infrastructure;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso3166.Migrations;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso3166;

/// <summary>
/// An Entity Framework Core Database Context for ISO 3166 codes.
/// </summary>
public sealed class Iso3166SqlServerDbContext : IsoDbContext
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166SqlServerDbContext" />.
    /// </summary>
    /// <param name="isoSqlServerOptions">
    /// The configuration options <see cref="IsoSqlServerOptions" />.
    /// </param>
    public Iso3166SqlServerDbContext(IsoSqlServerOptions isoSqlServerOptions)
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
            .ReplaceService<IMigrationsModelDiffer, Iso3166MigrationsModelDiffer>()
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
        modelBuilder.ApplyIso3166(schemaName);
        base.OnModelCreating(modelBuilder);
    }
}
