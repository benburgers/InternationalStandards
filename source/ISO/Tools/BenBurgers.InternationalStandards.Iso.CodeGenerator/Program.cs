/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.CodeGenerator.Configuration;
using BenBurgers.InternationalStandards.Iso.CodeGenerator.Workflow.Iso3166;
using BenBurgers.InternationalStandards.Iso.CodeGenerator.Workflow.Iso4217;
using BenBurgers.InternationalStandards.Iso.CodeGenerator.Workflow.Iso639;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

// Bootstrap
var environment =
    Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
    ?? "Development";
var configuration =
    new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{environment}.json", true)
        .AddCommandLine(args)
        .Build();
var serviceProvider =
    new ServiceCollection()
        .AddLogging(builder =>
        {
            builder
                .AddSimpleConsole(options =>
                {
                    options.IncludeScopes = true;
                });
            builder.AddConfiguration(configuration.GetSection("Logging"));
        })
        .Configure<CodeGeneratorOptions>(configuration.GetSection("CodeGenerator"))
        .BuildServiceProvider();

// Run
var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMinutes(5.0D));
var cancellationToken = cancellationTokenSource.Token;
var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
var options = serviceProvider.GetRequiredService<IOptions<CodeGeneratorOptions>>().Value;
if (options.Iso639 is { } iso639Options)
    await Iso639CodeGenerator.GenerateAsync(iso639Options, logger, cancellationToken);
if (options.Iso3166 is { } iso3166Options)
    await Iso3166CodeGenerator.GenerateAsync(iso3166Options, logger, cancellationToken);
if (options.Iso4217 is { } iso4217Options)
    await Iso4217CodeGenerator.GenerateAsync(iso4217Options, logger, cancellationToken);