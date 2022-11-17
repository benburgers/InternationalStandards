/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166;
using BenBurgers.InternationalStandards.Iso.Iso3166.Exceptions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Iso3166.Storage.ValueConversion.Alpha;

/// <summary>
/// An Entity Framework Core value converter for ISO 3166 Alpha codes.
/// </summary>
public sealed class Iso3166AlphaValueConverter : ValueConverter<Iso3166Code, string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166AlphaValueConverter" /> .
    /// </summary>
    /// <param name="options">
    /// The ISO 3166 Alpha Value Converter configuration options.
    /// </param>
    public Iso3166AlphaValueConverter(Iso3166AlphaValueConverterOptions options)
        : base(GetConvertToProviderExpression(options), GetConvertFromProviderExpression())
    {
    }

    /// <inheritdoc />
    /// <exception cref="Iso3166AlphaInvalidException">
    /// An <see cref="Iso3166AlphaInvalidException" /> is thrown if an invalid Alpha value is encountered.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// An <see cref="ArgumentNullException" /> is thrown if a <see langword="null" /> is encountered as a value.
    /// </exception>
    public override Expression<Func<string, Iso3166Code>> ConvertFromProviderExpression => base.ConvertFromProviderExpression;

    private static Expression<Func<Iso3166Code, string>> GetConvertToProviderExpression(Iso3166AlphaValueConverterOptions options)
    {
        return options.AlphaMode switch
        {
            Iso3166AlphaMode.Alpha2 => code => code.ToAlpha2(),
            Iso3166AlphaMode.Alpha3 => code => code.ToAlpha3(),
            _ => code => code.ToAlpha2()
        };
    }

    private static Expression<Func<string, Iso3166Code>> GetConvertFromProviderExpression()
    {
        return code => code.ToIso3166();
    }
}
