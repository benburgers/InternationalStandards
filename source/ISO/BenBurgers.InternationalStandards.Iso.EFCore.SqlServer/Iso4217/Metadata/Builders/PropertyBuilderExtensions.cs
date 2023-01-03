/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Iso4217.Storage.ValueConversion.Alpha;
using BenBurgers.InternationalStandards.Iso.EFCore.Iso4217.Storage.ValueConversion.Numeric;
using BenBurgers.InternationalStandards.Iso.Iso4217;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso4217.Metadata.Builders;

/// <summary>
/// Extension methods for Entity Framework Core Property Builders for <see cref="Iso4217Code" />.
/// </summary>
[SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "Enhancement of EF Core API.")]
public static class PropertyBuilderExtensions
{
    /// <summary>
    /// Configures the property so that the property is converted to and from the database as an Alpha code.
    /// </summary>
    /// <param name="propertyBuilder">
    /// The property builder from Entity Framework Core.
    /// </param>
    /// <returns>
    /// The property builder from Entity Framework Core.
    /// </returns>
    public static PropertyBuilder<Iso4217Code> HasIso4217Alpha(
        this PropertyBuilder<Iso4217Code> propertyBuilder)
    {
        var mapping = new SqlServerStringTypeMapping(fixedLength: true, size: 3, sqlDbType: SqlDbType.Char);
        return
            propertyBuilder
                .HasConversion(new Iso4217AlphaValueConverter())
                .HasColumnType(mapping.StoreType);
    }

    /// <summary>
    /// Configures the property so that the property is converted to and from the database as a numeric code.
    /// </summary>
    /// <param name="propertyBuilder">
    /// The property builder from Entity Framework Core.
    /// </param>
    /// <returns>
    /// The property builder from Entity Framework Core.
    /// </returns>
    public static PropertyBuilder<Iso4217Code> HasIso4217Numeric(
        this PropertyBuilder<Iso4217Code> propertyBuilder)
    {
        var mapping = new SqlServerShortTypeMapping("smallint");
        return
            propertyBuilder
                .HasConversion(new Iso4217NumericValueConverter())
                .HasColumnType(mapping.StoreType);
    }
}
