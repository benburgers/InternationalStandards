/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Iso8601.Storage.ValueConversion;

/// <summary>
/// Converts an <see cref="Iso8601CalendarDate" /> to a <see cref="DateOnly" /> and vice versa.
/// </summary>
public sealed class Iso8601CalendarDateToDateOnlyValueConverter : ValueConverter<Iso8601CalendarDate, DateOnly>
{
    private static Expression<Func<Iso8601CalendarDate, DateOnly>> GetConvertToProviderExpression() =>
        d => d.ToDate();

    private static Expression<Func<DateOnly, Iso8601CalendarDate>> GetConvertFromProviderExpression(bool simple) =>
        d => new Iso8601CalendarDate(d, simple);

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601CalendarDateToDateOnlyValueConverter" />.
    /// </summary>
    /// <param name="simple">
    /// A value that indicates whether the ISO 8601 Calendar Date has a simple representation by default.
    /// The default value is <see langword="false" />.
    /// </param>
    public Iso8601CalendarDateToDateOnlyValueConverter(bool simple = false)
        : base(GetConvertToProviderExpression(), GetConvertFromProviderExpression(simple))
    {
        this.Simple = simple;
    }

    /// <summary>
    /// Gets a value that indicates whether the ISO 8601 Calendar Date has a simple representation by default.
    /// </summary>
    public bool Simple { get; }
}
