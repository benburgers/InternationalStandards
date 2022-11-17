/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Configuration;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Infrastructure;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso3166.Migrations;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso3166;

/// <summary>
/// An Entity Framework Core Database Context for ISO 3166 codes.
/// </summary>
public sealed class Iso3166SqlServerDbContext : DbContext
{
    private readonly IsoSqlServerOptions isoSqlServerOptions;

    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166SqlServerDbContext" />.
    /// </summary>
    /// <param name="isoSqlServerOptions">
    /// The configuration options <see cref="IsoSqlServerOptions" />.
    /// </param>
    public Iso3166SqlServerDbContext(IsoSqlServerOptions isoSqlServerOptions)
        : base(CreateOptions(isoSqlServerOptions))
    {
        this.isoSqlServerOptions = isoSqlServerOptions;
    }

    private static DbContextOptions CreateOptions(IsoSqlServerOptions isoSqlServerOptions)
    {
        return
            new DbContextOptionsBuilder()
                .ReplaceService<IMigrationsModelDiffer, Iso3166MigrationsModelDiffer>()
                .ReplaceService<IMigrationsSqlGenerator, IsoMigrationsSqlGenerator>()
                .UseSqlServer(isoSqlServerOptions.ConnectionString)
                .Options
                .WithExtension(new IsoDbContextOptionsExtension(isoSqlServerOptions));
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyIso3166(this.isoSqlServerOptions.SchemaName);
    }
}
