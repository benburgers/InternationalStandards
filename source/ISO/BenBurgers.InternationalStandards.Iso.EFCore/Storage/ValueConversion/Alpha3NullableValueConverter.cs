/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Exceptions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Storage.ValueConversion;

/// <summary>
/// Converts <see cref="Alpha3" /> from and to <see cref="string" />.
/// </summary>
public sealed class Alpha3NullableValueConverter : ValueConverter<Alpha3?, string?>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Alpha3ValueConverter" />.
    /// </summary>
    public Alpha3NullableValueConverter()
        : base(GetConvertToProviderExpression(), GetConvertFromProviderExpression())
    {
    }

    /// <inheritdoc />
    /// <exception cref="AlphaLengthException">
    /// An <see cref="AlphaLengthException" /> is thrown if the value does not have the required length.
    /// </exception>
    public override Expression<Func<string?, Alpha3?>> ConvertFromProviderExpression => base.ConvertFromProviderExpression;

    private static Expression<Func<Alpha3?, string?>> GetConvertToProviderExpression()
    {
        return alpha => alpha == null ? null : alpha.Value;
    }

    private static Expression<Func<string?, Alpha3?>> GetConvertFromProviderExpression()
    {
        return alpha => alpha == null ? null : new Alpha3(alpha);
    }
}
