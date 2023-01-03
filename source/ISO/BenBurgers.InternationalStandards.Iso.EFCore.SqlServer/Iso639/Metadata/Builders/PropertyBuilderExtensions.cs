/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Iso639.Storage.ValueConversion.Alpha;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso639.Exceptions;
using BenBurgers.InternationalStandards.Iso.Iso639;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso639.Metadata.Builders;

/// <summary>
/// Extension methods for Entity Framework Core Property Builders for <see cref="Iso639Code" />.
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
    /// The ISO 639 Alpha Value Converter options.
    /// </param>
    /// <returns>
    /// The property builder from Entity Framework Core.
    /// </returns>
    /// <exception cref="Iso639PartNotSupportedException">
    /// An <see cref="Iso639PartNotSupportedException" /> is thrown if the specified ISO 639 Part in <paramref name="options" /> is not supported.
    /// </exception>
    public static PropertyBuilder<Iso639Code> HasIso639Alpha(
        this PropertyBuilder<Iso639Code> propertyBuilder,
        Iso639AlphaValueConverterOptions options)
    {
        var size =
            options.Part switch
            {
                Iso639Part.Part1 => 2,
                Iso639Part.Part2T => 3,
                Iso639Part.Part2B => 3,
                Iso639Part.Part3 => 3,
                _ => throw new Iso639PartNotSupportedException(options.Part)
            };

        var mapping = new SqlServerStringTypeMapping(fixedLength: true, size: size, sqlDbType: SqlDbType.Char);

        return
            propertyBuilder
                .HasConversion(new Iso639AlphaValueConverter(options))
                .HasColumnType(mapping.StoreType);
    }
}
