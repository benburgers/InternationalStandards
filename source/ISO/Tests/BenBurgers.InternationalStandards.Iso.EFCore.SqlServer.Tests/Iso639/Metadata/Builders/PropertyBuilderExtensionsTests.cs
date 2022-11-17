/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.EFCore.Iso639.Storage.ValueConversion.Alpha;
using BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso639.Metadata.Builders;
using BenBurgers.InternationalStandards.Iso.Iso639;
using Microsoft.EntityFrameworkCore;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Tests.Iso639.Metadata.Builders;

public class PropertyBuilderExtensionsTests
{
    private record TestModel(
        Guid Id,
        Iso639Code Iso639code);

    public static readonly IEnumerable<object?[]> HasIso639AlphaParameters =
        new[]
        {
            new object?[] { Iso639Part.Part1, "char(2)" },
            new object?[] { Iso639Part.Part2T, "char(3)" },
            new object?[] { Iso639Part.Part2B, "char(3)" },
            new object?[] { Iso639Part.Part3, "char(3)" }
        };

    [Theory(DisplayName = "ISO 639 property builder sets the expected metadata.")]
    [MemberData(nameof(HasIso639AlphaParameters))]
    public void HasIso639AlphaTest(Iso639Part part, string expectedColumnType)
    {
        // Arrange
        var options = new Iso639AlphaValueConverterOptions(part);
        var entityTypeBuilder = new ModelBuilder().Entity<TestModel>();

        // Act
        entityTypeBuilder
            .Property(e => e.Iso639code)
            .HasIso639Alpha(options);

        // Assert
        var property =
            entityTypeBuilder
                .Metadata
                .GetProperty(nameof(TestModel.Iso639code));
        var valueConverter = property.GetValueConverter();
        Assert.IsType<Iso639AlphaValueConverter>(valueConverter);
        var actualColumnType = property.GetColumnType();
        Assert.Equal(expectedColumnType, actualColumnType);
    }
}
