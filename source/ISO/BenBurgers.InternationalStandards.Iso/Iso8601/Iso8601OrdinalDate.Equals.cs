/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601OrdinalDate
{
    private bool Equals(Iso8601OrdinalDate other) =>
        this.Year.Equals(other.Year)
        && this.DayOfYear.Equals(other.DayOfYear)
        && this.Simple.Equals(other.Simple);

    /// <inheritdoc />
    public override bool Equals([NotNullWhen(true)] object? obj) =>
        obj switch
        {
            null => false,
            DateOnly other => this.ToDate().Equals(other),
            DateTime other => this.ToDateTime().Equals(other),
            DateTimeOffset other => this.ToDateTimeOffset().Equals(other),
            Iso8601CalendarDate other => other.Equals(this),
            Iso8601OrdinalDate other => this.Equals(other),
            _ => false
        };

    /// <inheritdoc />
    public override int GetHashCode() =>
        HashCode.Combine(this.Year, this.DayOfYear, this.Simple);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the parameters are equal.</returns>
    public static bool operator ==(Iso8601OrdinalDate left, Iso8601OrdinalDate right) =>
        left.Equals(right);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are not equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the parameters are not equal.</returns>
    public static bool operator !=(Iso8601OrdinalDate left, Iso8601OrdinalDate right) =>
        !left.Equals(right);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the date and object are equal.</returns>
    public static bool operator ==(Iso8601OrdinalDate left, object? right) =>
        left.Equals(right);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are not equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the date and object are not equal.</returns>
    public static bool operator !=(Iso8601OrdinalDate left, object? right) =>
        !left.Equals(right);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the date and object are equal.</returns>
    public static bool operator ==(object? left, Iso8601OrdinalDate right) =>
        right.Equals(left);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are not equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the date and object are not equal.</returns>
    public static bool operator !=(object? left, Iso8601OrdinalDate right) =>
        !right.Equals(left);
}
