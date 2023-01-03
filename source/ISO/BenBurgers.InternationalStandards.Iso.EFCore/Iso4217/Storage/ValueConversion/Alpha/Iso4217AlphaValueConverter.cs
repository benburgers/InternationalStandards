/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;
using BenBurgers.InternationalStandards.Iso.Iso4217.Exceptions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Iso4217.Storage.ValueConversion.Alpha;

/// <summary>
/// An Entity Framework Core value converter for ISO 4217 Alpha codes.
/// </summary>
public sealed class Iso4217AlphaValueConverter : ValueConverter<Iso4217Code, string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217AlphaValueConverter" />.
    /// </summary>
    public Iso4217AlphaValueConverter()
        : base(GetConvertToProviderExpression(), GetConvertFromProviderExpression())
    {
    }

    /// <inheritdoc />
    /// <exception cref="Iso4217AlphaInvalidException">
    /// An <see cref="Iso4217AlphaInvalidException" /> is thrown if a value is encountered that does not have a valid Alpha code.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// An <see cref="ArgumentNullException" /> is thrown if a <see langword="null" /> is encountered as a value.
    /// </exception>
    public override Expression<Func<string, Iso4217Code>> ConvertFromProviderExpression => base.ConvertFromProviderExpression;

    private static Expression<Func<Iso4217Code, string>> GetConvertToProviderExpression()
    {
        return code => code.ToAlpha();
    }

    private static Expression<Func<string, Iso4217Code>> GetConvertFromProviderExpression()
    {
        return code => code.ToIso4217();
    }
}
