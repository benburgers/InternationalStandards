/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Iso3166.Storage.ValueConversion.Numeric;

/// <summary>
/// An Entity Framework Core value converter for ISO 3166 numeric codes.
/// </summary>
public sealed class Iso3166NumericValueConverter : ValueConverter<Iso3166Code, int>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166NumericValueConverter" />.
    /// </summary>
    public Iso3166NumericValueConverter()
        : base(GetConvertToProviderExpression(), GetConvertFromProviderExpression())
    {
    }

    private static Expression<Func<Iso3166Code, int>> GetConvertToProviderExpression()
    {
        return code => (int)code;
    }

    private static Expression<Func<int, Iso3166Code>> GetConvertFromProviderExpression()
    {
        return code => (Iso3166Code)code;
    }
}
