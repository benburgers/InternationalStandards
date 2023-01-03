/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;
using BenBurgers.InternationalStandards.Iso.Iso639.Attributes;
using BenBurgers.InternationalStandards.Iso.Iso639.Exceptions;
using System.Reflection;

namespace BenBurgers.InternationalStandards.Iso.Tests.Iso639;

public class Iso639CodeTests
{
    public static readonly IEnumerable<object?[]> AllCodesHaveAttributesParameters =
        typeof(Iso639Code)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(f =>
                new object?[]
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

    public static readonly IEnumerable<object?[]> ToPart1Parameters =
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

    public static readonly IEnumerable<object?[]> ToPart1MissingParameters =
        new[]
        {
            new object?[] { Iso639Code.Abé, true },
            new object?[] { Iso639Code.Latin, false }
        };

    [Theory(DisplayName = "ISO 639 code throws exception if ISO 639-1 Alpha-2 code is missing when requested.")]
    [MemberData(nameof(ToPart1MissingParameters))]
    public void ToPart1TestMissing(Iso639Code iso639Code, bool throwException)
    {
        if (throwException)
        {
            var exception = Assert.Throws<Iso639PartNotAssignedException>(() =>
            {
                iso639Code.ToPart1();
            });
            Assert.Equal(iso639Code, exception.Code);
            Assert.Equal(Iso639Part.Part1, exception.Part);
        }
        else
        {
            var part1 = iso639Code.ToPart1();
            Assert.NotNull(part1);
        }
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

    public static readonly IEnumerable<object?[]> ToPart2MissingParameters =
        new[]
        {
            new object?[] { Iso639Code.Abé, true },
            new object?[] { Iso639Code.Latin, false }
        };

    [Theory(DisplayName = "ISO 639 code throws exception if ISO 639-2T Alpha-3 code or ISO 639-2B Alpha-3 dode is missing when requested.")]
    [MemberData(nameof(ToPart2MissingParameters))]
    public void ToPart2TestMissing(Iso639Code iso639Code, bool throwException)
    {
        if (throwException)
        {
            var exceptionT = Assert.Throws<Iso639PartNotAssignedException>(() =>
            {
                iso639Code.ToPart2(Iso639Part2Type.Terminological);
            });
            Assert.Equal(iso639Code, exceptionT.Code);
            Assert.Equal(Iso639Part.Part2T, exceptionT.Part);
            var exceptionB = Assert.Throws<Iso639PartNotAssignedException>(() =>
            {
                iso639Code.ToPart2(Iso639Part2Type.Bibliographic);
            });
            Assert.Equal(iso639Code, exceptionB.Code);
            Assert.Equal(Iso639Part.Part2B, exceptionB.Part);
        }
        else
        {
            var part2 = iso639Code.ToPart2(Iso639Part2Type.Terminological);
            Assert.NotNull(part2);
        }
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

    public static readonly IEnumerable<object?[]> ToIso639Parameters =
        new[]
        {
            new object?[] { "aar", Iso639Code.Afar },
            new object?[] { "nl", Iso639Code.Dutch_Flemish }
        };

    [Theory(DisplayName = "ISO 639 Alpha codes can be converted to ISO 639 codes.")]
    [MemberData(nameof(ToIso639Parameters))]
    public void ToIso639Tests(string input, Iso639Code expected)
    {
        var actual = input.ToIso639();
        Assert.Equal(expected, actual);
    }

    public static readonly IEnumerable<object?[]> TryToIso639Parameters =
        new[]
        {
            new object?[] { "az", true, false, Iso639Code.Azerbaijani },
            new object?[] { "aze", true, false, Iso639Code.Azerbaijani },
            new object?[] { "a", false, false, null }
        };

    [Theory(DisplayName = "ISO 639 :: TryTo639")]
    [MemberData(nameof(TryToIso639Parameters))]
    public void TryToIso639Test(
        string input,
        bool expectedValid,
        bool allowDeprecated,
        Iso639Code? expectedCode)
    {
        var actualValid = input.TryToIso639(out var actualCode, allowDeprecated);
        Assert.Equal(expectedValid, actualValid);
        Assert.Equal(expectedCode, actualCode);
    }
}
