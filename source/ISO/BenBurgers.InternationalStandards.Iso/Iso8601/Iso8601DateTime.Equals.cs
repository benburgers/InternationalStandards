/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601DateTime
{
    private bool Equals(Iso8601DateTime other) =>
        this.Date.Equals(other.Date)
        && this.Time.Equals(other.Time);

    /// <inheritdoc />
    public override bool Equals([NotNullWhen(true)] object? obj) =>
        obj switch
        {
            null => false,
            DateTime other => this.ToDateTime().Equals(other),
            DateTimeOffset other => this.ToDateTimeOffset().Equals(other),
            Iso8601DateTime other => this.Equals(other),
            _ => false
        };

    /// <inheritdoc />
    public override int GetHashCode() =>
        HashCode.Combine(this.Date, this.Time);

    /// <summary>
    /// Determines whether the date and time are equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the date and time are equal.</returns>
    public static bool operator ==(Iso8601DateTime left, Iso8601DateTime right) =>
        left.Equals(right);

    /// <summary>
    /// Determines whether the date and time are not equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the date and time are not equal.</returns>
    public static bool operator !=(Iso8601DateTime left, Iso8601DateTime right) =>
        !left.Equals(right);

    /// <summary>
    /// Determines whether the date and time and object are equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the date and time and object are equal.</returns>
    public static bool operator ==(Iso8601DateTime left, object? right) =>
        left.Equals(right);

    /// <summary>
    /// Determines whether the date and time and object are not equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the date and time and object are not equal.</returns>
    public static bool operator !=(Iso8601DateTime left, object? right) =>
        !left.Equals(right);

    /// <summary>
    /// Determines whether the object and date and time are equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the object and date and time are equal.</returns>
    public static bool operator ==(object? left, Iso8601DateTime right) =>
        right.Equals(left);

    /// <summary>
    /// Determines whether the object and date and time are not equal.
    /// </summary>
    /// <param name="left">The left hand side parameter.</param>
    /// <param name="right">The right hand side parameter.</param>
    /// <returns>A value that indicates whether the object and date and time are not equal.</returns>
    public static bool operator !=(object? left, Iso8601DateTime right) =>
        !right.Equals(left);
}
