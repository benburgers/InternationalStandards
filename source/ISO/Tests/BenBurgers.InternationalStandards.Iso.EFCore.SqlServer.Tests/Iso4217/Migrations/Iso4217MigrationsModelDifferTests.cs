/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Configuration;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Infrastructure;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso4217;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Tests.Bootstrap;
using BenBurgers.InternationalStandards.Iso.Iso4217;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Tests.Iso4217.Migrations;

[Collection(nameof(ConfigurationTestCollection))]
public class Iso4217MigrationsModelDifferTests
{
    private readonly ConfigurationTestFixture configurationTestFixture;

    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217MigrationsModelDifferTests" />.
    /// </summary>
    /// <param name="configurationTestFixture">
    /// A fixture for configuring tests.
    /// </param>
    public Iso4217MigrationsModelDifferTests(ConfigurationTestFixture configurationTestFixture)
    {
        this.configurationTestFixture = configurationTestFixture;
    }

    [Fact(DisplayName = "ISO 4217 Migrations Model Differ :: Get Differences")]
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
                MigrationsAssembly = typeof(Iso4217MigrationsModelDifferTests).Assembly.FullName,
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
        var targetDbContext = new Iso4217SqlServerDbContext(isoSqlServerOptions);
        var target = targetDbContext.GetService<IDesignTimeModel>().Model.GetRelationalModel();
        var migrationsModelDiffer = targetDbContext.GetService<IMigrationsModelDiffer>();

        // Act
        var differences = migrationsModelDiffer.GetDifferences(source, target);

        // Assert
        Assert.NotEmpty(differences);
        var codes = Enum.GetValues(typeof(Iso4217Code)).Cast<Iso4217Code>().ToArray();

        var codesCount = codes.Length;
        Assert.Contains(
            differences,
            d => d is InsertDataOperation { Table: { } table, Values: { } values }
                    && table == nameof(Iso4217Code)
                    && values.GetLength(0) == codesCount);

        var entitiesCount = codes.SelectMany(c => c.ToModel().Entities).DistinctBy(e => e.Name).Count();
        Assert.Contains(
            differences,
            d => d is InsertDataOperation { Table: { } table, Values: { } values }
                    && table == nameof(Iso4217Entity)
                    && values.GetLength(0) == entitiesCount);

        Assert.Contains(
            differences,
            d => d is InsertDataOperation { Table: { } table, Values: { } values }
                    && table == $"{nameof(Iso4217Code)}_{nameof(Iso4217Entity)}");
    }
}
