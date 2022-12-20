/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;
using Microsoft.EntityFrameworkCore;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso639;

/// <summary>
/// Extension methods for building models for ISO 639.
/// </summary>
internal static class ModelBuilderExtensions
{
    /// <summary>
    /// Applies configuration for the <see cref="Iso639Model" />.
    /// </summary>
    /// <param name="modelBuilder">
    /// The model builder from Entity Framework Core.
    /// </param>
    /// <param name="schemaName">
    /// The name of the SQL Server Schema for ISO standards.
    /// </param>
    /// <param name="allowDeprecated">
    /// A <see cref="bool" /> value that indicates whether deprecated codes are allowed.
    /// </param>
    /// <returns>
    /// The model builder from Entity Framework Core.
    /// </returns>
    internal static ModelBuilder ApplyIso639(
        this ModelBuilder modelBuilder,
        string schemaName,
        bool allowDeprecated = false)
    {
        return
            modelBuilder
                .ApplyConfiguration(new Iso639ModelEntityTypeConfiguration(schemaName, allowDeprecated));
    }
}
