/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;
using Microsoft.EntityFrameworkCore;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso4217;

/// <summary>
/// Extension methods for building models for ISO 4217.
/// </summary>
internal static class ModelBuilderExtensions
{
    /// <summary>
    /// Applies configuration for the <see cref="Iso4217Model" />.
    /// </summary>
    /// <param name="modelBuilder">
    /// The model builder from Entity Framework Core.
    /// </param>
    /// <param name="schemaName">
    /// The name of the SQL Server Schema for ISO standards.
    /// </param>
    /// <returns>
    /// The model builder from Entity Framework Core.
    /// </returns>
    internal static ModelBuilder ApplyIso4217(this ModelBuilder modelBuilder, string schemaName)
    {
        return
            modelBuilder
                .ApplyConfiguration(new Iso4217SqlServerEntityConfiguration(schemaName))
                .ApplyConfiguration(new Iso4217SqlServerModelConfiguration(schemaName));
    }
}
