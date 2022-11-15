/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using System.Globalization;
using System.Reflection;
using BenBurgers.InternationalStandards.Iso.Iso3166.Attributes;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso3166;

public class Iso3166CodeTests
{
    public static IEnumerable<object?[]> NamesParameters =>
        new[]
        {
            new object?[] { null },
            new object?[] { new CultureInfo("en") },
            new object?[] { new CultureInfo("fr") },
            new object?[] { new CultureInfo("nl") }
        };

    [Fact(DisplayName = "All ISO 3166 codes have a metadata attribute.")]
    public void AttributesTest()
    {
        // Arrange
        var fields =
            typeof(Iso3166Code)
                .GetFields(BindingFlags.Public | BindingFlags.Static);

        // Act
        var attributes =
            fields
                .Select(f => f.GetCustomAttribute<Iso3166Attribute>())
                .ToArray();

        // Assert
        Assert.True(attributes.All(a => a is not null));
    }

    [Theory(DisplayName = "All ISO 3166 codes have a short and long name.")]
    [MemberData(nameof(NamesParameters))]
    public void NamesTest(CultureInfo cultureInfo)
    {
        // Arrange
        var fields =
            typeof(Iso3166Code)
                .GetFields(BindingFlags.Public | BindingFlags.Static);

        // Act
        var names =
            fields
                .Select(f =>
                {
                    var value = (Iso3166Code)f.GetValue(null)!;
                    var nameShort = value.GetName(Iso3166NameVariant.Short, cultureInfo);
                    var nameLong = value.GetName(Iso3166NameVariant.Long, cultureInfo);
                    return (Value: value, NameShort: nameShort, NameLong: nameLong);
                })
                .ToArray();

        // Assert
        Assert.True(
            names
                .All(v =>
                    !string.IsNullOrWhiteSpace(v.NameShort)
                    && !string.IsNullOrWhiteSpace(v.NameLong))
                );
    }
}
