/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Infrastructure;

/// <summary>
/// An extension of Database Context Options for ISO codes.
/// </summary>
internal sealed class IsoDbContextOptionsExtension : IDbContextOptionsExtension
{
    private sealed class ExtensionInfo : DbContextOptionsExtensionInfo
    {
        internal ExtensionInfo(IDbContextOptionsExtension extension)
            : base(extension)
        {
        }

        public override bool IsDatabaseProvider => false;

        public override string LogFragment => "ISO";

        public override int GetServiceProviderHashCode()
        {
            return nameof(IsoDbContextOptionsExtension).GetHashCode();
        }

        public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
        {
            debugInfo["SchemaName"] = ((IsoDbContextOptionsExtension)this.Extension).SchemaName;
        }

        public override bool ShouldUseSameServiceProvider(DbContextOptionsExtensionInfo other)
        {
            return other is ExtensionInfo;
        }
    }

    private ExtensionInfo? extensionInfo;

    /// <summary>
    /// Initializes a new instance of <see cref="IsoDbContextOptionsExtension" />.
    /// </summary>
    /// <param name="isoSqlServerOptions">
    /// The SQL Server configuration options for ISO standards.
    /// </param>
    public IsoDbContextOptionsExtension(IsoSqlServerOptions isoSqlServerOptions)
    {
        this.SchemaName = isoSqlServerOptions.SchemaName;
    }

    /// <summary>
    /// Gets the extension information.
    /// </summary>
    public DbContextOptionsExtensionInfo Info => this.extensionInfo ??= new ExtensionInfo(this);

    /// <summary>
    /// Gets the name of the schema to use for ISO tables.
    /// </summary>
    public string SchemaName { get; }

    /// <inheritdoc />
    public void ApplyServices(IServiceCollection services)
    {
    }

    /// <inheritdoc />
    public void Validate(IDbContextOptions options)
    {
    }
}
