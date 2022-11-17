/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Metadata.Builders;

/// <summary>
/// Extension methods for Entity Framework Core Property Builders for alpha codes.
/// </summary>
[SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "Enhancement of EF Core API.")]
public static class PropertyBuilderExtensions
{
    /// <summary>
    /// Configures the property so that the property is converted to and from the database as a 2-character string.
    /// </summary>
    /// <param name="propertyBuilder">
    /// The property builder from Entity Framework Core.
    /// </param>
    /// <returns>
    /// The property builder from Entity Framework Core.
    /// </returns>
    public static PropertyBuilder<Alpha2> HasAlpha2(
        this PropertyBuilder<Alpha2> propertyBuilder)
    {
        var mapping = new SqlServerStringTypeMapping(size: 2, fixedLength: true);

        return
            propertyBuilder
                .HasConversion(new Alpha2ValueConverter())
                .HasColumnType(mapping.StoreType);
    }

    /// <summary>
    /// Configures the property so that the property is converted to and from the database as a 2-character string.
    /// </summary>
    /// <param name="propertyBuilder">
    /// The property builder from Entity Framework Core.
    /// </param>
    /// <returns>
    /// The property builder from Entity Framework Core.
    /// </returns>
    public static PropertyBuilder<Alpha2?> HasAlpha2Nullable(
        this PropertyBuilder<Alpha2?> propertyBuilder)
    {
        var mapping = new SqlServerStringTypeMapping(size: 2, fixedLength: true);

        return
            propertyBuilder
                .HasConversion(new Alpha2NullableValueConverter())
                .HasColumnType(mapping.StoreType);
    }


    /// <summary>
    /// Configures the property so that the property is converted to and from the database as a 3-character string.
    /// </summary>
    /// <param name="propertyBuilder">
    /// The property builder from Entity Framework Core.
    /// </param>
    /// <returns>
    /// The property builder from Entity Framework Core.
    /// </returns>
    public static PropertyBuilder<Alpha3> HasAlpha3(
        this PropertyBuilder<Alpha3> propertyBuilder)
    {
        var mapping = new SqlServerStringTypeMapping(size: 3, fixedLength: true);

        return
            propertyBuilder
                .HasConversion(new Alpha3ValueConverter())
                .HasColumnType(mapping.StoreType);
    }

    /// <summary>
    /// Configures the property so that the property is converted to and from the database as a 3-character string.
    /// </summary>
    /// <param name="propertyBuilder">
    /// The property builder from Entity Framework Core.
    /// </param>
    /// <returns>
    /// The property builder from Entity Framework Core.
    /// </returns>
    public static PropertyBuilder<Alpha3?> HasAlpha3Nullable(
        this PropertyBuilder<Alpha3?> propertyBuilder)
    {
        var mapping = new SqlServerStringTypeMapping(size: 3, fixedLength: true);

        return
            propertyBuilder
                .HasConversion(new Alpha3NullableValueConverter())
                .HasColumnType(mapping.StoreType);
    }
}
