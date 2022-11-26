/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Configuration;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Infrastructure;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso3166;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso3166.Migrations;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Tests.Bootstrap;
using BenBurgers.InternationalStandards.Iso.Iso3166;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Tests.Iso3166.Migrations;

/// <summary>
/// Tests for <see cref="Iso3166MigrationsModelDiffer" />.
/// </summary>
[Collection(nameof(ConfigurationTestCollection))]
public class Iso3166MigrationsModelDifferTests
{
    private readonly ConfigurationTestFixture configurationTestFixture;

    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166MigrationsModelDifferTests" />.
    /// </summary>
    /// <param name="configurationTestFixture">
    /// A fixture for configuring tests.
    /// </param>
    public Iso3166MigrationsModelDifferTests(ConfigurationTestFixture configurationTestFixture)
    {
        this.configurationTestFixture = configurationTestFixture;
    }

    [Fact(DisplayName = "ISO 3166 Migrations Model Differ :: Get Differences")]
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
                MigrationsAssembly = typeof(Iso3166MigrationsModelDifferTests).Assembly.FullName,
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
        var targetDbContext = new Iso3166SqlServerDbContext(isoSqlServerOptions);
        var target = targetDbContext.GetService<IDesignTimeModel>().Model.GetRelationalModel();
        var migrationsModelDiffer = targetDbContext.GetService<IMigrationsModelDiffer>();

        // Act
        var differences = migrationsModelDiffer.GetDifferences(source, target);

        // Assert
        Assert.NotEmpty(differences);
        var codes = Enum.GetValues(typeof(Iso3166Code)).Cast<Iso3166Code>().ToArray();
        Assert.Contains(
            differences,
            d => d is InsertDataOperation { Table: { } table, Values: { } values }
                    && table == nameof(Iso3166Code)
                    && values.GetLength(0) == codes.Length);
    }
}
