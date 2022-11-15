/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;
using BenBurgers.InternationalStandards.Iso.Iso4217.Attributes;
using System.Reflection;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso4217;

public class Iso4217CodeTests
{
    public static readonly IEnumerable<object?[]> AllCodesHaveAttributesParameters =
        typeof(Iso4217Code)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(f =>
                new object?[]
                {
                    (Iso4217Code)f.GetValue(null)!,
                    f.GetCustomAttributes<Iso4217EntityAttribute>().Any(),
                    f.GetCustomAttributes<Iso4217CurrencyNameAttribute>().Any(),
                    f.GetCustomAttributes<Iso4217AlphaAttribute>().Any()
                });

    [Theory(DisplayName = "All ISO 4217 codes have attributes.")]
    [MemberData(nameof(AllCodesHaveAttributesParameters))]
    public void AllIso4217CodesHaveAttributesTest(
        Iso4217Code iso4217Code,
        bool hasEntityAttribute,
        bool hasCurrencyNameAttribute,
        bool hasAlphaAttribute)
    {
        Assert.True(hasEntityAttribute, $"'{iso4217Code}' does not have an entity attribute.");
        Assert.True(hasCurrencyNameAttribute, $"'{iso4217Code}' does not have a currency name attribute.");
        Assert.True(hasAlphaAttribute, $"'{iso4217Code}' does not have an alpha attribute.");
    }

    public static readonly IEnumerable<object?[]> ToAlphaParameters =
        new[]
        {
            new object?[] { Iso4217Code.Euro, "EUR" },
            new object?[] { Iso4217Code.USDollar, "USD" }
        };

    [Theory(DisplayName = "ISO 4217 codes can be converted to Alpha-3 three-letter codes.")]
    [MemberData(nameof(ToAlphaParameters))]
    public void ToAlphaTest(
        Iso4217Code iso4217Code,
        string expected)
    {
        var actual = iso4217Code.ToAlpha();
        Assert.Equal(expected, actual);
    }

    public static readonly IEnumerable<object?[]> GetEntitiesParameters =
        new[]
        {
            new object?[]
            {
                Iso4217Code.AustralianDollar,
                new []
                {
                    "AUSTRALIA",
                    "CHRISTMAS ISLAND",
                    "COCOS (KEELING) ISLANDS (THE)",
                    "HEARD ISLAND AND McDONALD ISLANDS",
                    "KIRIBATI",
                    "NAURU",
                    "NORFOLK ISLAND",
                    "TUVALU"
                }
            },
            new object?[]
            {
                Iso4217Code.IndianRupee,
                new []
                {
                    "BHUTAN",
                    "INDIA"
                }
            }
        };

    [Theory(DisplayName = "ISO 4217 codes can return their entities.")]
    [MemberData(nameof(GetEntitiesParameters))]
    public void GetEntitiesTest(
        Iso4217Code iso4217Code,
        string[] expected)
    {
        var actual = iso4217Code.GetEntities();
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object?[]> GetReferenceNameParameters =
        new[]
        {
            new object?[] { Iso4217Code.BrazilianReal, "Brazilian Real" },
            new object?[] { Iso4217Code.MoldovanLeu, "Moldovan Leu" }
        };

    [Theory(DisplayName = "ISO 4217 codes can return their reference name.")]
    [MemberData(nameof(GetReferenceNameParameters))]
    public void GetReferenceNameTest(
        Iso4217Code iso4217Code,
        string expected)
    {
        var actual = iso4217Code.GetReferenceName();
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object?[]> GetMinorUnitsParameters =
        new[]
        {
            new object?[] { Iso4217Code.FijiDollar, (byte?)2 },
            new object?[] { Iso4217Code.SwissFranc, (byte?)2 },
            new object?[] { Iso4217Code.ADBUnitOfAccount, null }
        };

    [Theory(DisplayName = "ISO 4217 codes can return their minor units.")]
    [MemberData(nameof(GetMinorUnitsParameters))]
    public void GetMinorUnitsTest(
        Iso4217Code iso4217Code,
        byte? expected)
    {
        var actual = iso4217Code.GetMinorUnits();
        Assert.Equal(expected, actual);
    }
}
