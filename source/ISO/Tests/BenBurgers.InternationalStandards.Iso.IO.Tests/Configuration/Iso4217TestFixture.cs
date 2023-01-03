/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Tests.Configuration;

public class Iso4217TestFixture
{
    public Iso4217TestFixture()
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
                .Configure<Iso4217TestOptions>(configuration.GetSection("Iso4217"))
                .BuildServiceProvider();
    }

    public IServiceProvider ServiceProvider { get; }
}
