/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Iso3166.Storage.ValueConversion.Alpha;
using BenBurgers.InternationalStandards.Iso.EFCore.Iso3166.Storage.ValueConversion.Numeric;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso3166.Exceptions;
using BenBurgers.InternationalStandards.Iso.Iso3166;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso3166.Metadata.Builders;

/// <summary>
/// Extension methods for Entity Framework Core Property Builders for <see cref="Iso3166Code" />.
/// </summary>
[SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "Enhancement of EF Core API.")]
public static class PropertyBuilderExtensions
{
    /// <summary>
    /// Configures the property so that the property is converted to and from the database as an Alpha code, as specified in <paramref name="options" />.
    /// </summary>
    /// <param name="propertyBuilder">
    /// The property builder from Entity Framework Core.
    /// </param>
    /// <param name="options">
    /// The ISO 3166 Alpha Value Converter options.
    /// </param>
    /// <returns>
    /// The property builder from Entity Framework Core.
    /// </returns>
    /// <exception cref="Iso3166AlphaModeNotSupportedException">
    /// An <see cref="Iso3166AlphaModeNotSupportedException" /> is thrown if the specified ISO 3166 Alpha Mode is not supported.
    /// </exception>
    public static PropertyBuilder<Iso3166Code> HasIso3166Alpha(
        this PropertyBuilder<Iso3166Code> propertyBuilder,
        Iso3166AlphaValueConverterOptions options)
    {
        var size =
            options.AlphaMode switch
            {
                Iso3166AlphaMode.Alpha2 => 2,
                Iso3166AlphaMode.Alpha3 => 3,
                _ => throw new Iso3166AlphaModeNotSupportedException(options.AlphaMode)
            };

        var mapping = new SqlServerStringTypeMapping(fixedLength: true, size: size, sqlDbType: SqlDbType.Char);

        return
            propertyBuilder
                .HasConversion(new Iso3166AlphaValueConverter(options))
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
    public static PropertyBuilder<Iso3166Code> HasIso3166Numeric(
        this PropertyBuilder<Iso3166Code> propertyBuilder)
    {
        var mapping = new SqlServerShortTypeMapping("smallint");

        return
            propertyBuilder
                .HasConversion(new Iso3166NumericValueConverter())
                .HasColumnType(mapping.StoreType);
    }
}
