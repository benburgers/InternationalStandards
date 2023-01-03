/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */
using BenBurgers.InternationalStandards.Iso.Iso8601;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace BenBurgers.InternationalStandards.Iso.EFCore.Iso8601.Storage.ValueConversion;

/// <summary>
/// Converts an <see cref="Iso8601Time" /> to a <see cref="TimeOnly" /> and vice versa.
/// </summary>
public sealed class Iso8601TimeToTimeOnlyValueConverter : ValueConverter<Iso8601Time, TimeOnly>
{
    private static Expression<Func<Iso8601Time, TimeOnly>> GetConvertToProviderExpression(TimeSpan? utcOffset) =>
        t => t.ToTime(utcOffset);

    private static Expression<Func<TimeOnly, Iso8601Time>> GetConvertFromProviderExpression(TimeSpan? utcOffset) =>
        t => Iso8601Time.FromTime(t, utcOffset);

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601TimeToTimeOnlyValueConverter" />.
    /// </summary>
    /// <param name="utcOffset">An optional UTC offset.</param>
    public Iso8601TimeToTimeOnlyValueConverter(TimeSpan? utcOffset = null)
        : base(GetConvertToProviderExpression(utcOffset), GetConvertFromProviderExpression(utcOffset))
    {
        this.UtcOffset = utcOffset;
    }

    /// <summary>
    /// Gets the optional UTC offset.
    /// </summary>
    public TimeSpan? UtcOffset { get; }
}
