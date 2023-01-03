/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Storage.ValueConversion;
using BenBurgers.InternationalStandards.Iso.Iso3166;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso3166;

/// <summary>
/// Entity Type Configuration for <see cref="Iso3166Model" />.
/// </summary>
[SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "Enhancement of EF Core API.")]
internal sealed class Iso3166ModelEntityTypeConfiguration : IEntityTypeConfiguration<Iso3166Model>
{
    private readonly string schemaName;

    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166ModelEntityTypeConfiguration" />.
    /// </summary>
    /// <param name="schemaName">
    /// The name of the SQL Server Schema for ISO tables.
    /// </param>
    internal Iso3166ModelEntityTypeConfiguration(string schemaName)
    {
        this.schemaName = schemaName;
    }

    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Iso3166Model> builder)
    {
        var numericTypeMapping = new SqlServerShortTypeMapping("smallint");
        var alpha2TypeMapping = new SqlServerStringTypeMapping(size: 2, fixedLength: true);
        var alpha3TypeMapping = new SqlServerStringTypeMapping(size: 3, fixedLength: true);

        builder.ToTable(nameof(Iso3166Code), this.schemaName);
        builder.HasKey(m => m.Numeric);
        builder
            .Property(m => m.Numeric)
            .HasColumnType(numericTypeMapping.StoreType);
        builder
            .Property(m => m.Alpha2)
            .HasConversion(new Alpha2ValueConverter())
            .HasColumnType(alpha2TypeMapping.StoreType);
        builder
            .Property(m => m.Alpha3)
            .HasConversion(new Alpha3ValueConverter())
            .HasColumnType(alpha3TypeMapping.StoreType);
        builder.Ignore(m => m.FullName);
        builder.Ignore(m => m.ShortName);
        builder.Ignore(m => m.ShortNameUpperCase);
        builder.HasData(Enum.GetValues<Iso3166Code>().Select(c => c.ToModel()));
    }
}
