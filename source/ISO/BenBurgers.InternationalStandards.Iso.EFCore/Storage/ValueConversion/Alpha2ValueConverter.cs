/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Exceptions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Storage.ValueConversion;

/// <summary>
/// Converts <see cref="Alpha2" /> from and to <see cref="string" />.
/// </summary>
public sealed class Alpha2ValueConverter : ValueConverter<Alpha2, string>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Alpha2ValueConverter" />.
    /// </summary>
    public Alpha2ValueConverter()
        : base(GetConvertToProviderExpression(), GetConvertFromProviderExpression())
    {
    }

    /// <inheritdoc />
    /// <exception cref="AlphaLengthException">
    /// An <see cref="AlphaLengthException" /> is thrown if the value does not have the required length.
    /// </exception>
    public override Expression<Func<string, Alpha2>> ConvertFromProviderExpression => base.ConvertFromProviderExpression;

    private static Expression<Func<Alpha2, string>> GetConvertToProviderExpression()
    {
        return alpha => alpha.Value;
    }

    private static Expression<Func<string, Alpha2>> GetConvertFromProviderExpression()
    {
        return alpha => new Alpha2(alpha);
    }
}
