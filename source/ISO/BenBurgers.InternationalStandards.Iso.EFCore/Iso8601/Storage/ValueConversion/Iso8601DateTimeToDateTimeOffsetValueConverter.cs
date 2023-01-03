/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Iso8601.Storage.ValueConversion;

/// <summary>
/// Converts an <see cref="Iso8601DateTime" /> to a <see cref="DateTimeOffset" />.
/// </summary>
public sealed class Iso8601DateTimeToDateTimeOffsetValueConverter : ValueConverter<Iso8601DateTime, DateTimeOffset>
{
    private static Expression<Func<Iso8601DateTime, DateTimeOffset>> GetConvertToProviderExpression() =>
        d => d.ToDateTimeOffset();

    private static Expression<Func<DateTimeOffset, Iso8601DateTime>> GetConvertFromProviderExpression() =>
        d => Iso8601DateTime.FromDateTimeOffset(d);

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601DateTimeToDateTimeOffsetValueConverter" />.
    /// </summary>
    public Iso8601DateTimeToDateTimeOffsetValueConverter()
        : base(GetConvertToProviderExpression(), GetConvertFromProviderExpression())
    {
    }
}
