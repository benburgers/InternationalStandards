/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso4217;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Iso4217.Storage.ValueConversion.Numeric;

/// <summary>
/// An Entity Framework Core value converter for ISO 4217 numeric codes.
/// </summary>
public sealed class Iso4217NumericValueConverter : ValueConverter<Iso4217Code, int>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217NumericValueConverter" />.
    /// </summary>
    public Iso4217NumericValueConverter()
        : base(GetConvertToProviderExpression(), GetConvertFromProviderExpression())
    {
    }

    private static Expression<Func<Iso4217Code, int>> GetConvertToProviderExpression()
    {
        return code => (int)code;
    }

    private static Expression<Func<int, Iso4217Code>> GetConvertFromProviderExpression()
    {
        return code => (Iso4217Code)code;
    }
}
