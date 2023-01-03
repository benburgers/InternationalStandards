/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Iso4217.Storage.ValueConversion.Alpha;
using BenBurgers.InternationalStandards.Iso.EFCore.Iso4217.Storage.ValueConversion.Numeric;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso4217.Metadata.Builders;
using BenBurgers.InternationalStandards.Iso.Iso4217;
using Microsoft.EntityFrameworkCore;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Tests.Iso4217.Metadata.Builders;

public class PropertyBuilderExtensionsTests
{
    private record TestModel(
        Guid Id,
        Iso4217Code Iso4217Code);

    [Fact(DisplayName = "ISO 4217 property builder builds property for Alpha value.")]
    public void HasIso4217AlphaTest()
    {
        // Arrange
        var entityTypeBuilder = new ModelBuilder().Entity<TestModel>();

        // Act
        entityTypeBuilder
            .Property(e => e.Iso4217Code)
            .HasIso4217Alpha();

        // Assert
        var property =
            entityTypeBuilder
                .Metadata
                .GetProperty(nameof(TestModel.Iso4217Code));
        var valueConverter = property.GetValueConverter();
        Assert.IsType<Iso4217AlphaValueConverter>(valueConverter);
        var columnType = property.GetColumnType();
        Assert.Equal("char(3)", columnType);
    }

    [Fact(DisplayName = "ISO 4217 property builder builds property for numeric value.")]
    public void HasIso4217NumericTest()
    {
        // Arrange
        var entityTypeBuilder = new ModelBuilder().Entity<TestModel>();

        // Act
        entityTypeBuilder
            .Property(e => e.Iso4217Code)
            .HasIso4217Numeric();

        // Assert
        var property =
            entityTypeBuilder
                .Metadata
                .GetProperty(nameof(TestModel.Iso4217Code));
        var valueConverter = property.GetValueConverter();
        Assert.IsType<Iso4217NumericValueConverter>(valueConverter);
        var columnType = property.GetColumnType();
        Assert.Equal("smallint", columnType);
    }
}
