/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Tests.Configuration;

public class Iso639TestFixture
{
    public Iso639TestFixture()
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
                .Configure<Iso639TestOptions>(configuration.GetSection("Iso639"))
                .BuildServiceProvider();
    }

    public IServiceProvider ServiceProvider { get; }
}
