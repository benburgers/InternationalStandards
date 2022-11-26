/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Configuration;

/// <summary>
/// Initializes a new instance of <see cref="IsoSqlServerOptions" />.
/// </summary>
public sealed class IsoSqlServerOptions
{
    /// <summary>
    /// The connection string.
    /// </summary>
    public string? ConnectionString { get; init; }

    /// <summary>
    /// The name of the assembly that contains the migrations.
    /// </summary>
    public string? MigrationsAssembly { get; init; }

    /// <summary>
    /// A <see cref="bool" /> value that indicates whether to log sensitive data.
    /// </summary>
    public bool EnableSensitiveDataLogging { get; init; } = false;

    /// <summary>
    /// The name of the SQL Server Schema for the tables related to ISO standards.
    /// </summary>
    public string SchemaName { get; init; } = "ISO";

    /// <summary>
    /// Deconstructs <see cref="IsoSqlServerOptions" /> into its constituent fields.
    /// </summary>
    /// <param name="connectionString">
    /// The SQL Server connection string.
    /// </param>
    /// <param name="migrationsAssembly">
    /// The migrations assembly.
    /// </param>
    /// <param name="enableSensitiveDataLogging">
    /// A value that indicates whether sensitive data logging is enabled.
    /// </param>
    /// <param name="schemaName">
    /// The schema name.
    /// </param>
    public void Deconstruct(
        out string? connectionString,
        out string? migrationsAssembly,
        out bool? enableSensitiveDataLogging,
        out string? schemaName)
    {
        connectionString = this.ConnectionString;
        migrationsAssembly = this.MigrationsAssembly;
        enableSensitiveDataLogging = this.EnableSensitiveDataLogging;
        schemaName = this.SchemaName;
    }
}