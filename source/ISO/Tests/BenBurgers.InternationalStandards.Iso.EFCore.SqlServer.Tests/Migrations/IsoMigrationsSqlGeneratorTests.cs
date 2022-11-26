/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Configuration;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Infrastructure;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso3166;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Migrations;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Tests.Bootstrap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Tests.Migrations;

/// <summary>
/// Tests for <see cref="IsoMigrationsSqlGenerator" />.
/// </summary>
[Collection(nameof(ConfigurationTestCollection))]
public class IsoMigrationsSqlGeneratorTests
{
    private readonly ConfigurationTestFixture configurationTestFixture;

    /// <summary>
    /// Initializes a new instance of <see cref="IsoMigrationsSqlGeneratorTests" />.
    /// </summary>
    /// <param name="configurationTestFixture">
    /// The fixture for test configuration.
    /// </param>
    public IsoMigrationsSqlGeneratorTests(ConfigurationTestFixture configurationTestFixture)
    {
        this.configurationTestFixture = configurationTestFixture;
    }

    [Fact(DisplayName = "ISO Migrations SQL Generator :: Generate")]
    public void GenerateTest()
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
                MigrationsAssembly = typeof(IsoMigrationsSqlGeneratorTests).Assembly.FullName,
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
        var sqlGenerator = targetDbContext.GetService<IMigrationsSqlGenerator>();

        // Act
        var migrationOperations = migrationsModelDiffer.GetDifferences(source, target);
        var commands = sqlGenerator.Generate(migrationOperations);

        // Assert
        Assert.NotEmpty(commands);
        Assert.Equal(4, commands.Count);
        var permissions = commands[3].CommandText.Split(Environment.NewLine);
        Assert.Equal("DENY DELETE ON SCHEMA :: BBIso TO public", permissions[0]);
        Assert.Equal("DENY INSERT ON SCHEMA :: BBIso TO public", permissions[1]);
        Assert.Equal("DENY UPDATE ON SCHEMA :: BBIso TO public", permissions[2]);
    }
}
