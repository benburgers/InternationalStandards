/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Configuration;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer;

/// <summary>
/// An Entity Framework Core Database Context for ISO standards.
/// </summary>
public abstract class IsoDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of <see cref="IsoDbContext" />.
    /// </summary>
    /// <param name="options">
    /// The options for configuring ISO standards using Entity Framework Core SQL Server.
    /// </param>
    protected IsoDbContext(IsoSqlServerOptions options)
        : base(new DbContextOptionsBuilder().Options.WithExtension(new IsoDbContextOptionsExtension(options)))
    {
        this.IsoSqlServerOptions = options;
    }

    /// <summary>
    /// Gets the options for configuring ISO standards using Entity Framework Core SQL Server.
    /// </summary>
    protected IsoSqlServerOptions IsoSqlServerOptions { get; }
}
