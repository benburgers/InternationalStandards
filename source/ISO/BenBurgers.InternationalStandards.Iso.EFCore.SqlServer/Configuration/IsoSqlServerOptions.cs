/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Configuration;

/// <summary>
/// Initializes a new instance of <see cref="IsoSqlServerOptions" />.
/// </summary>
/// <param name="ConnectionString">
/// The connection string.
/// </param>
/// <param name="EnableSensitiveDataLogging">
/// A <see cref="bool" /> value that indicates whether to log sensitive data.
/// </param>
/// <param name="SchemaName">
/// The name of the SQL Server Schema for the tables related to ISO standards.
/// </param>
public sealed record IsoSqlServerOptions(
    string ConnectionString,
    bool EnableSensitiveDataLogging = false,
    string SchemaName = "ISO");