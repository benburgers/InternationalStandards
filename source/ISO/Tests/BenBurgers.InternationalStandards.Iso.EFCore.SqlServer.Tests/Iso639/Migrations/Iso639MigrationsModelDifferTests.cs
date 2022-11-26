/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso639.Migrations;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Tests.Bootstrap;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using BenBurgers.InternationalStandards.Iso.Iso639;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Infrastructure;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Configuration;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso639;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Tests.Iso639.Migrations;

[Collection(nameof(ConfigurationTestCollection))]
public class Iso639MigrationsModelDifferTests
{
    private readonly ConfigurationTestFixture configurationTestFixture;

    /// <summary>
    /// Initializes a new instance of <see cref="Iso639MigrationsModelDiffer" />.
    /// </summary>
    /// <param name="configurationTestFixture">
    /// A fixture for configuring tests.
    /// </param>
    public Iso639MigrationsModelDifferTests(ConfigurationTestFixture configurationTestFixture)
    {
        this.configurationTestFixture = configurationTestFixture;
    }

    [Fact(DisplayName = "ISO 639 Migrations Model Differ :: Get Differences")]
    public void GetDifferencesTest()
    {
        // Arrange
        var serviceProvider = this.configurationTestFixture.ServiceProvider;
        var testOptions =
            serviceProvider
                .GetRequiredService<IOptions<ConfigurationTestOptions>>()
                .Value;
        var connectionString = testOptions.ConnectionString;
        var schemaName = testOptions.SchemaName;
        var isoSqlServerOptions =
            new IsoSqlServerOptions
            {
                ConnectionString = connectionString,
                MigrationsAssembly = typeof(Iso639MigrationsModelDifferTests).Assembly.FullName,
                EnableSensitiveDataLogging = true,
                SchemaName = schemaName
            };

        var dbContextOptions =
            new DbContextOptionsBuilder<DbContext>()
                .UseSqlServer(connectionString)
                .EnableSensitiveDataLogging()
                .Options
                .WithExtension(new IsoDbContextOptionsExtension(isoSqlServerOptions));
        var sourceDbContext = new DbContext(dbContextOptions);
        var source = sourceDbContext.GetService<IDesignTimeModel>().Model.GetRelationalModel();
        var targetDbContext = new Iso639SqlServerDbContext(isoSqlServerOptions);
        var target = targetDbContext.GetService<IDesignTimeModel>().Model.GetRelationalModel();
        var migrationsModelDiffer = targetDbContext.GetService<IMigrationsModelDiffer>();

        // Act
        var differences = migrationsModelDiffer.GetDifferences(source, target);

        // Assert
        Assert.NotEmpty(differences);
        var codes = Enum.GetValues(typeof(Iso639Code)).Cast<Iso639Code>().ToArray();

        var codesCount = codes.Length;
        Assert.Contains(
            differences,
            d => d is InsertDataOperation { Table: { } table, Values: { } values }
                    && table == nameof(Iso639Code)
                    && values.GetLength(0) == codesCount);
    }
}
