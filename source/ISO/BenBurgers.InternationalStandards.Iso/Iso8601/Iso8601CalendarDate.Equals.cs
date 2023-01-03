/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601CalendarDate
{
    private bool Equals(Iso8601CalendarDate other) =>
        this.Year.Equals(other.Year)
        && this.Month.Equals(other.Month)
        && this.Day.Equals(other.Day)
        && this.Simple.Equals(other.Simple);

    /// <inheritdoc />
    public override bool Equals([NotNullWhen(true)] object? obj) =>
        obj switch
        {
            null => false,
            DateOnly other => this.ToDate().Equals(other),
            DateTime other => this.ToDateTime().Equals(other),
            DateTimeOffset other => this.ToDateTimeOffset().Equals(other),
            Iso8601CalendarDate other => this.Equals(other),
            Iso8601OrdinalDate other => this.Equals(other),
            _ => false
        };

    private bool Equals(Iso8601OrdinalDate other) =>
        this.Equals(new DateOnly(other.Year, 1, 1, Calendar).AddDays(other.DayOfYear - 1));

    /// <inheritdoc />
    public override int GetHashCode() =>
        HashCode.Combine(this.Year, this.Month, this.Day, this.Simple);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the parameters are equal.</returns>
    public static bool operator ==(Iso8601CalendarDate left, Iso8601CalendarDate right) =>
        left.Equals(right);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are not equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the parameters are not equal.</returns>
    public static bool operator !=(Iso8601CalendarDate left, Iso8601CalendarDate right) =>
        !left.Equals(right);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the date and object are equal.</returns>
    public static bool operator ==(Iso8601CalendarDate left, object? right) =>
        left.Equals(right);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are not equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the date and object are not equal.</returns>
    public static bool operator !=(Iso8601CalendarDate left, object? right) =>
        !left.Equals(right);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the date and object are equal.</returns>
    public static bool operator ==(object? left, Iso8601CalendarDate right) =>
        right.Equals(left);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are not equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the date and object are not equal.</returns>
    public static bool operator !=(object? left, Iso8601CalendarDate right) =>
        !right.Equals(left);
}
