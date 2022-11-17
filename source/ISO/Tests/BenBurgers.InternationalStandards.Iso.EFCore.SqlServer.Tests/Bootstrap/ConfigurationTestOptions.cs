/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Tests.Bootstrap;

/// <summary>
/// Options for test configuration.
/// </summary>
public sealed class ConfigurationTestOptions
{
    /// <summary>
    /// Gets or sets the connection string.
    /// </summary>
    public string ConnectionString { get; set; } = default!;

    /// <summary>
    /// Gets or sets the SQL Server Schema name for ISO tables.
    /// </summary>
    public string SchemaName { get; set; } = "BBIso";
}
