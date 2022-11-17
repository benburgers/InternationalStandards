/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Configuration;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Infrastructure;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso639.Migrations;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso639;

/// <summary>
/// An Entity Framework Core Database Context for ISO 639 codes.
/// </summary>
public sealed class Iso639SqlServerDbContext : DbContext
{
    private readonly IsoSqlServerOptions isoSqlServerOptions;

    /// <summary>
    /// Initializes a new instance of <see cref="Iso639SqlServerDbContext" />.
    /// </summary>
    /// <param name="isoSqlServerOptions">
    /// The configuration options for <see cref="IsoSqlServerOptions" />.
    /// </param>
    public Iso639SqlServerDbContext(IsoSqlServerOptions isoSqlServerOptions)
        : base(CreateOptions(isoSqlServerOptions))
    {
        this.isoSqlServerOptions = isoSqlServerOptions;
    }

    private static DbContextOptions CreateOptions(IsoSqlServerOptions isoSqlServerOptions)
    {
        var (connectionString, enableSensitiveDataLogging, _) = isoSqlServerOptions;
        return
            new DbContextOptionsBuilder()
                .ReplaceService<IMigrationsModelDiffer, Iso639MigrationsModelDiffer>()
                .ReplaceService<IMigrationsSqlGenerator, IsoMigrationsSqlGenerator>()
                .UseSqlServer(connectionString)
                .EnableSensitiveDataLogging(enableSensitiveDataLogging)
                .Options
                .WithExtension(new IsoDbContextOptionsExtension(isoSqlServerOptions));
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyIso639(this.isoSqlServerOptions.SchemaName);
    }
}
