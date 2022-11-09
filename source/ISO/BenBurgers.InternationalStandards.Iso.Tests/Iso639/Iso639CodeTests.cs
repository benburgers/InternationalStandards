/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;
using BenBurgers.InternationalStandards.Iso.Iso639.Attributes;
using BenBurgers.InternationalStandards.Iso.Iso639.Exceptions;
using System.Reflection;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso639;

public class Iso639CodeTests
{
    public static readonly IEnumerable<object[]> AllCodesHaveAttributesParameters =
        typeof(Iso639Code)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(f =>
                new object[]
                {
                    (Iso639Code)f.GetValue(null)!,
                    f.GetCustomAttributes<Iso639Part1Attribute>().Any(),
                    f.GetCustomAttributes<Iso639Part2Attribute>().Any(),
                    f.GetCustomAttributes<Iso639Part3Attribute>().Any(),
                    f.GetCustomAttributes<Iso639ScopeAttribute>().Any(),
                    f.GetCustomAttributes<Iso639LanguageTypeAttribute>().Any()
                });

    [Theory(DisplayName = "All ISO 639 codes have attributes.")]
    [MemberData(nameof(AllCodesHaveAttributesParameters))]
    public void AllIso639CodesHaveAttributesTest(
        Iso639Code iso639Code,
        bool hasIso639Part1Attribute,
        bool hasIso639Part2Attribute,
        bool hasIso639Part3Attribute,
        bool hasIso639ScopeAttribute,
        bool hasIso639LanguageTypeAttribute)
    {
        Assert.True(hasIso639Part1Attribute || hasIso639Part2Attribute || hasIso639Part3Attribute, $"'{iso639Code}' does not have at least one ISO 639 code attribute.");
        Assert.True(hasIso639ScopeAttribute, $"'{iso639Code}' does not have an ISO 639 Scope attribute.");
        Assert.True(hasIso639LanguageTypeAttribute, $"'{iso639Code}' does not have an ISO 639 Language Type attribute.");
    }

    public static IEnumerable<object?[]> ToPart1Parameters =
        new[]
        {
            new object?[] { Iso639Code.Arabic, "ar", false, false },
            // new object?[] { Iso639Code.Bihari, "bh", false, true }, TODO uncomment when deprecated codes are imported
            // new object?[] { Iso639Code.Bihari, "bh", true, false }, TODO uncomment when deprecated codes are imported
            new object?[] { Iso639Code.Danish, "da", false, false }
        };

    [Theory(DisplayName = "ISO 639 codes can be converted to ISO 639-1 Alpha-2 codes.")]
    [MemberData(nameof(ToPart1Parameters))]
    public void ToPart1Tests(
        Iso639Code iso639Code,
        string expected,
        bool allowDeprecated,
        bool catchException)
    {
        if (catchException)
        {
            Assert.Throws<Iso639CodeDeprecatedException>(() =>
            {
                iso639Code.ToPart1(allowDeprecated);
            });
            return;
        }

        var actual = iso639Code.ToPart1(allowDeprecated);
        Assert.Equal(expected, actual);
    }

    public static readonly IEnumerable<object?[]> ToPart2Parameters =
        new[]
        {
            new object?[] { Iso639Code.Albanian, "sqi", "alb" },
            new object?[] { Iso639Code.Arabic, "ara", "ara" }
        };

    [Theory(DisplayName = "ISO 639 codes can be converted to ISO 639-2T and ISO 639-2B Alpha-3 codes.")]
    [MemberData(nameof(ToPart2Parameters))]
    public void ToPart2Tests(
        Iso639Code iso639Code,
        string expectedT,
        string expectedB)
    {
        var actualT = iso639Code.ToPart2(Iso639Part2Type.Terminological);
        var actualB = iso639Code.ToPart2(Iso639Part2Type.Bibliographic);
        Assert.Equal(expectedT, actualT);
        Assert.Equal(expectedB, actualB);
    }

    public static readonly IEnumerable<object?[]> ToPart3Parameters =
        new[]
        {
            new object?[] { Iso639Code.Albanian, "sqi" },
            new object?[] { Iso639Code.English, "eng" }
        };

    [Theory(DisplayName = "ISO 639 codes can be converted to ISO 639-3 Alpha-3 codes.")]
    [MemberData(nameof(ToPart3Parameters))]
    public void ToPart3Tests(
        Iso639Code iso639Code,
        string expected)
    {
        var actual = iso639Code.ToPart3();
        Assert.Equal(expected, actual);
    } 
}
