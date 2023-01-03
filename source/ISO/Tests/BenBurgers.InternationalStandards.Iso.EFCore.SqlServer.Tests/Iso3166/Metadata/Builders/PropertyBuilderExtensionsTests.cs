/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Iso3166.Storage.ValueConversion.Alpha;
using BenBurgers.InternationalStandards.Iso.EFCore.Iso3166.Storage.ValueConversion.Numeric;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso3166.Metadata.Builders;
using BenBurgers.InternationalStandards.Iso.Iso3166;
using Microsoft.EntityFrameworkCore;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Tests.Iso3166.Metadata.Builders;

public class PropertyBuilderExtensionsTests
{
    private record TestModel(
        Guid Id,
        Iso3166Code Iso3166Code);

    public static readonly IEnumerable<object?[]> HasIso3166AlphaParameters =
        new[]
        {
            new object?[] { new Iso3166AlphaValueConverterOptions(Iso3166AlphaMode.Alpha2), "char(2)" },
            new object?[] { new Iso3166AlphaValueConverterOptions(Iso3166AlphaMode.Alpha3), "char(3)" }
        };

    [Theory(DisplayName = "ISO 3166 property builder builds property for Alpha value.")]
    [MemberData(nameof(HasIso3166AlphaParameters))]
    public void HasIso3166AlphaTest(Iso3166AlphaValueConverterOptions options, string expectedColumnType)
    {
        // Arrange
        var entityTypeBuilder = new ModelBuilder().Entity<TestModel>();

        // Act
        entityTypeBuilder
            .Property(e => e.Iso3166Code)
            .HasIso3166Alpha(options);

        // Assert
        var property =
            entityTypeBuilder
                .Metadata
                .GetProperty(nameof(TestModel.Iso3166Code));
        var valueConverter = property.GetValueConverter();
        Assert.IsType<Iso3166AlphaValueConverter>(valueConverter);
        var actualColumnType = property.GetColumnType();
        Assert.Equal(expectedColumnType, actualColumnType);
    }

    [Fact(DisplayName = "ISO 3166 property builder builds property for numeric value.")]
    public void HasIso3166NumericTest()
    {
        // Arrange
        var entityTypeBuilder = new ModelBuilder().Entity<TestModel>();

        // Act
        entityTypeBuilder
            .Property(e => e.Iso3166Code)
            .HasIso3166Numeric();

        // Assert
        var property =
            entityTypeBuilder
                .Metadata
                .GetProperty(nameof(TestModel.Iso3166Code));
        var valueConverter = property.GetValueConverter();
        Assert.IsType<Iso3166NumericValueConverter>(valueConverter);
        var columnType = property.GetColumnType();
        Assert.Equal("smallint", columnType);
    }
}
