/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Configuration;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Design;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso3166;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations;

public sealed class Iso3166DesignTimeDbContextFactory : IsoDesignTimeDbContextFactory<Iso3166SqlServerDbContext>
{
    protected override IsoSqlServerOptions? IsoSqlServerOptions => new()
    {
        ConnectionString = "Server=localhost;Database=InternationalStandards_Dev;Persist Security Info=True;Integrated Security=SSPI;TrustServerCertificate=True",
        EnableSensitiveDataLogging = true,
        MigrationsAssembly = typeof(Iso3166DesignTimeDbContextFactory).Assembly.FullName,
        SchemaName = "test"
    };
}
