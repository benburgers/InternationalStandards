/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso4217;

internal sealed class Iso4217ModelEntityConfiguration : IEntityTypeConfiguration<Iso4217Entity>
{
    private readonly string schemaName;

    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217ModelEntityConfiguration" />.
    /// </summary>
    /// <param name="schemaName">
    /// The name of the SQL Server Schema for ISO tables.
    /// </param>
    internal Iso4217ModelEntityConfiguration(string schemaName)
    {
        this.schemaName = schemaName;
    }

    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Iso4217Entity> builder)
    {
        builder.ToTable(nameof(Iso4217Entity), this.schemaName);
        builder.HasKey(e => e.Name);
        builder.HasData(
            Enum
                .GetValues(typeof(Iso4217Code))
                .Cast<Iso4217Code>()
                .SelectMany(c => c.ToModel().Entities)
                .DistinctBy(e => e.Name));
    }
}
