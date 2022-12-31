/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Iso8601.Storage.ValueConversion;

/// <summary>
/// Converts an <see cref="Iso8601OrdinalDate" /> to a <see cref="DateOnly" />.
/// </summary>
public sealed class Iso8601OrdinalDateToDateOnlyValueConverter : ValueConverter<Iso8601OrdinalDate, DateOnly>
{
    private static Expression<Func<Iso8601OrdinalDate, DateOnly>> GetConvertToProviderExpression() =>
        d => d.ToDate();

    private static Expression<Func<DateOnly, Iso8601OrdinalDate>> GetConvertFromProviderExpression(bool simple) =>
        d => Iso8601OrdinalDate.FromDate(d, simple);

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601OrdinalDateToDateOnlyValueConverter" />.
    /// </summary>
    /// <param name="simple">
    /// A value that indicates whether ISO 8601 Ordinal Date has a simple representation by default.
    /// The default value is <see langword="false" />.
    /// </param>
    public Iso8601OrdinalDateToDateOnlyValueConverter(bool simple = false)
        : base(GetConvertToProviderExpression(), GetConvertFromProviderExpression(simple))
    {
        this.Simple = simple;
    }

    /// <summary>
    /// Gets a value that indicates whether the ISO 8601 Ordinal Date has a simple representation by default.
    /// </summary>
    public bool Simple { get; }
}
