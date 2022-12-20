/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Metadata.Builders;
using BenBurgers.InternationalStandards.Iso.Iso639;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso639;

/// <summary>
/// Entity Type Configuration for <see cref="Iso639Model" />.
/// </summary>
internal sealed class Iso639ModelEntityTypeConfiguration : IEntityTypeConfiguration<Iso639Model>
{
    private readonly string schemaName;
    private readonly bool allowDeprecated;

    /// <summary>
    /// Initializes a new instance of <see cref="Iso639ModelEntityTypeConfiguration" />.
    /// </summary>
    /// <param name="schemaName">
    /// The name of the SQL Server Schema for ISO tables.
    /// </param>
    /// <param name="allowDeprecated">
    /// A <see cref="bool" /> value that indicates whether deprecated codes are allowed.
    /// </param>
    internal Iso639ModelEntityTypeConfiguration(
        string schemaName,
        bool allowDeprecated = false)
    {
        this.schemaName = schemaName;
        this.allowDeprecated = allowDeprecated;
    }

    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Iso639Model> builder)
    {
        builder.ToTable(nameof(Iso639Code), this.schemaName);
        builder.Property(c => c.InvertedName);
        builder
            .Property(c => c.LanguageType)
            .HasConversion(new EnumToStringConverter<Iso639LanguageType>());
        builder
            .Property(c => c.Part1)
            .HasAlpha2Nullable();
        builder
            .Property(c => c.Part2T)
            .HasAlpha3Nullable();
        builder
            .Property(c => c.Part2B)
            .HasAlpha3Nullable();
        builder
            .Property(c => c.Part3)
            .HasAlpha3Nullable();
        builder.Property(c => c.PrintName);
        builder.Property(c => c.RefName);
        builder
            .Property(c => c.Scope)
            .HasConversion(new EnumToStringConverter<Iso639Scope>());
        builder.HasKey(m => m.Part3);
        builder.HasData(
            Enum
                .GetValues<Iso639Code>()
                .Cast<Iso639Code>()
                .Select(c => c.ToModel(this.allowDeprecated)));
    }
}
