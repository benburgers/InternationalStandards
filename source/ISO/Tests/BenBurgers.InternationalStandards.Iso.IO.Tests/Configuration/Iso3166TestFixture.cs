/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Tests.Configuration;

public class Iso3166TestFixture
{
    public Iso3166TestFixture()
    {
        var environment =
            Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
            ?? "Development";
        var configuration =
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();
        this.ServiceProvider =
            new ServiceCollection()
                .Configure<Iso3166TestOptions>(configuration.GetSection("Iso3166"))
                .BuildServiceProvider();
    }

    public IServiceProvider ServiceProvider { get; }
}
