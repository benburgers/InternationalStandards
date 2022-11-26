/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Configuration;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Exceptions;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Design;

/// <summary>
/// A Design Time Database Context Factory for an ISO Database Context.
/// </summary>
/// <typeparam name="TDbContext">
/// The type of Database Context.
/// </typeparam>
public class IsoDesignTimeDbContextFactory<TDbContext> : IDesignTimeDbContextFactory<TDbContext>
    where TDbContext : IsoDbContext
{
    /// <summary>
    /// Gets the options for configuring ISO standards services for Entity Framework Core SQL Server.
    /// </summary>
    protected virtual IsoSqlServerOptions? IsoSqlServerOptions { get; } = null;

    private Dictionary<string, string?> GetInheritedOptions()
    {
        return
            this.IsoSqlServerOptions is not { } inherited
                ? new Dictionary<string, string?>()
                : new Dictionary<string, string?>
                {
                    { nameof(IsoSqlServerOptions.ConnectionString), inherited.ConnectionString },
                    { nameof(IsoSqlServerOptions.EnableSensitiveDataLogging), inherited.EnableSensitiveDataLogging.ToString() },
                    { nameof(IsoSqlServerOptions.MigrationsAssembly), inherited.MigrationsAssembly },
                    { nameof(IsoSqlServerOptions.SchemaName), inherited.SchemaName }
                };
    }

    /// <inheritdoc />
    /// <exception cref="IsoSqlServerDesignTimeNotConfiguredException">
    /// An <see cref="IsoSqlServerDesignTimeNotConfiguredException" /> is thrown if the design time services have not been configured properly.
    /// </exception>
    public TDbContext CreateDbContext(string[] args)
    {
        if (this.IsoSqlServerOptions is null && args.Length == 0)
            throw new IsoSqlServerDesignTimeNotConfiguredException();
        var configuration =
            new ConfigurationBuilder()
                .AddInMemoryCollection(this.GetInheritedOptions())
                .AddCommandLine(args)
                .Build();
        var serviceProvider =
            new ServiceCollection()
                .Configure<IsoSqlServerOptions>(configuration)
                .BuildServiceProvider();
        var isoSqlServerOptions =
            serviceProvider
                .GetRequiredService<IOptions<IsoSqlServerOptions>>()
                .Value;
        return (TDbContext)Activator.CreateInstance(typeof(TDbContext), isoSqlServerOptions)!;
    }
}
