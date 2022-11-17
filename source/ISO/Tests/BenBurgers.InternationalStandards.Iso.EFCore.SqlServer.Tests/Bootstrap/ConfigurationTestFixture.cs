/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Tests.Bootstrap;

/// <summary>
/// A fixture for test configuration.
/// </summary>
public class ConfigurationTestFixture
{
    /// <summary>
    /// Initializes a new instance of <see cref="ConfigurationTestFixture" />.
    /// </summary>
    public ConfigurationTestFixture()
    {
        var environment =
            Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
            ?? "Development";
        var configuration =
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", true)
                .Build();
        this.ServiceProvider =
            new ServiceCollection()
                .Configure<ConfigurationTestOptions>(configuration.GetSection("Tests"))
                .BuildServiceProvider();
    }

    /// <summary>
    /// Gets the service provider for the tests.
    /// </summary>
    public IServiceProvider ServiceProvider { get; }
}
