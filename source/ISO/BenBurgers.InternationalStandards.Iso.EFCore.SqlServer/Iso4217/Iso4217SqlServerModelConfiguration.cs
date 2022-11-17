/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Storage.ValueConversion;
using BenBurgers.InternationalStandards.Iso.Iso4217;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso4217;

/// <summary>
/// Entity Type Configuration for <see cref="Iso4217Model" />.
/// </summary>
[SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "Enhancement of EF Core API.")]
internal sealed class Iso4217SqlServerModelConfiguration : IEntityTypeConfiguration<Iso4217Model>
{
    private const string EntityName = nameof(EntityName);
    private readonly string schemaName;

    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217SqlServerModelConfiguration" />.
    /// </summary>
    /// <param name="schemaName">
    /// The name of the SQL Server Schema for ISO tables.
    /// </param>
    internal Iso4217SqlServerModelConfiguration(string schemaName)
    {
        this.schemaName = schemaName;
    }

    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Iso4217Model> builder)
    {
        var currencyNumberTypeMapping = new SqlServerShortTypeMapping("smallint");
        var alpha3TypeMapping = new SqlServerStringTypeMapping(size: 3, fixedLength: true);
        var nameTypeMapping = new SqlServerStringTypeMapping();

        builder.ToTable(nameof(Iso4217Code), this.schemaName);
        builder
            .HasMany(m => m.Entities)
            .WithMany()
            .UsingEntity(etp =>
            {
                etp.ToTable($"{nameof(Iso4217Code)}_{nameof(Iso4217Entity)}", this.schemaName);
                etp.HasData(
                    Enum
                        .GetValues(typeof(Iso4217Code))
                        .Cast<Iso4217Code>()
                        .SelectMany(c => {
                            var model = c.ToModel();
                            return model.Entities.Select(
                                e => new
                                {
                                    Iso4217ModelCurrencyNumber = model.CurrencyNumber,
                                    EntitiesName = e.Name
                                });
                        }));
            });
        builder
            .Property(m => m.CurrencyNumber)
            .HasColumnType(currencyNumberTypeMapping.StoreType);
        builder
            .Property(m => m.Currency)
            .HasConversion(new Alpha3NullableValueConverter())
            .HasColumnType(alpha3TypeMapping.StoreType);
        builder
            .HasIndex(m => m.Currency)
            .IsUnique();
        builder
            .Property(m => m.CurrencyName)
            .IsRequired();
        builder
            .Property(m => m.CurrencyMinorUnits);
        builder.HasKey(m => m.CurrencyNumber);
        builder.HasData(
            Enum
                .GetValues<Iso4217Code>()
                .Cast<Iso4217Code>()
                .Select(c =>
                {
                    var model = c.ToModel();
                    return new Iso4217Model(
                        model.CurrencyName,
                        model.Currency,
                        model.CurrencyNumber,
                        model.CurrencyMinorUnits);
                }));
    }
}
