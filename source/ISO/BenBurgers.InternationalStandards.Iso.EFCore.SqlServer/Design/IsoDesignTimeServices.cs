/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations.Design;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations.Design;
using Microsoft.Extensions.DependencyInjection;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Design;

/// <summary>
/// Entity Framework Core design time services for ISO standards.
/// </summary>
public class IsoDesignTimeServices : IDesignTimeServices
{
    /// <inheritdoc />
    public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICSharpMigrationOperationGenerator, IsoCSharpMigrationOperationsGenerator>();
        serviceCollection.AddScoped<ICSharpSnapshotGenerator, IsoCSharpSnapshotGenerator>();
    }
}
