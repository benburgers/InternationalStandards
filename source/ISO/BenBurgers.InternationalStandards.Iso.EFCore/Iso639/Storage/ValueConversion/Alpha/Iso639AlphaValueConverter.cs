/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;
using BenBurgers.InternationalStandards.Iso.Iso639.Exceptions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Iso639.Storage.ValueConversion.Alpha;

/// <summary>
/// An Entity Framework Core value converter for ISO 4217 Alpha codes.
/// </summary>
public sealed class Iso639AlphaValueConverter : ValueConverter<Iso639Code, string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639AlphaValueConverter" />.
    /// </summary>
    /// <param name="options">
    /// The ISO 639 Alpha Value Converter configuration options.
    /// </param>
    public Iso639AlphaValueConverter(Iso639AlphaValueConverterOptions options)
        : base(GetConvertToProviderExpression(options), GetConvertFromProviderExpression(options))
    {
    }

    /// <inheritdoc />
    /// <exception cref="Iso639PartNotAssignedException">
    /// An <see cref="Iso639PartNotAssignedException" /> is thrown if a value is converted that does not have a representation in a particular ISO 639 Part.
    /// </exception>
    /// <exception cref="Iso639CodeDeprecatedException">
    /// An <see cref="Iso639CodeDeprecatedException" /> is thrown if a value is converted that represents a code that is deprecated while deprecated codes are not allowed.
    /// </exception>
    public override Expression<Func<Iso639Code, string>> ConvertToProviderExpression => base.ConvertToProviderExpression;

    private static Expression<Func<Iso639Code, string>> GetConvertToProviderExpression(Iso639AlphaValueConverterOptions options)
    {
        return options.Part switch
        {
            Iso639Part.Part1 => code => code.ToPart1(options.AllowDeprecated)!,
            Iso639Part.Part2T => code => code.ToPart2(Iso639Part2Type.Terminological, options.AllowDeprecated)!,
            Iso639Part.Part2B => code => code.ToPart2(Iso639Part2Type.Bibliographic, options.AllowDeprecated)!,
            Iso639Part.Part3 => code => code.ToPart3(options.AllowDeprecated)!,
#if NET6_0
            _ => code => code.ToPart3(options.AllowDeprecated)!
#endif
#if NET7_0_OR_GREATER
            _ => throw new System.Diagnostics.UnreachableException()
#endif
        };
    }

    private static Expression<Func<string, Iso639Code>> GetConvertFromProviderExpression(Iso639AlphaValueConverterOptions options) =>
        code => code.ToIso639(options.AllowDeprecated);
}
