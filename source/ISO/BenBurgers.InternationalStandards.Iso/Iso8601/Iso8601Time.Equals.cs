/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601Time
{
    private bool Equals(Iso8601Time other) =>
        this.Hour.Equals(other.Hour)
        && this.Minute.Equals(other.Minute)
        && this.Second.Equals(other.Second)
        && this.Fraction.Equals(other.Fraction)
        && this.UtcOffset.Equals(other.UtcOffset)
        && this.Simple.Equals(other.Simple);

    /// <inheritdoc />
    public override bool Equals([NotNullWhen(true)] object? obj) =>
        obj switch
        {
            null => false,
            TimeOnly other => this.ToTime().Equals(other),
            DateTime other => this.ToDateTime(other.Kind).Equals(other),
            DateTimeOffset other => this.ToDateTimeOffset().Equals(other),
            Iso8601Time other => this.Equals(other),
            _ => false
        };

    /// <inheritdoc />
    public override int GetHashCode() =>
        HashCode.Combine(this.Hour, this.Minute, this.Second, this.Fraction, this.UtcOffset, this.Simple);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are equal.
    /// </summary>
    /// <param name="left">The left hand side operand.</param>
    /// <param name="right">The right hand side operand.</param>
    /// <returns>A value that indicates whether the times are equal.</returns>
    public static bool operator ==(Iso8601Time left, Iso8601Time right) =>
        left.Equals(right);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are not equal.
    /// </summary>
    /// <param name="left">The left hand side operand.</param>
    /// <param name="right">The right hand side operand.</param>
    /// <returns>A value that indicates whether the times are not equal.</returns>
    public static bool operator !=(Iso8601Time left, Iso8601Time right) =>
        !left.Equals(right);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are equal.
    /// </summary>
    /// <param name="left">The left hand side operand.</param>
    /// <param name="right">The right hand side operand.</param>
    /// <returns>A value that indicates whether the time and object are equal.</returns>
    public static bool operator ==(Iso8601Time left, object? right) =>
        left.Equals(right);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are not equal.
    /// </summary>
    /// <param name="left">The left hand side operand.</param>
    /// <param name="right">The right hand side operand.</param>
    /// <returns>A value that indicates whether the time and object are not equal.</returns>
    public static bool operator !=(Iso8601Time left, object? right) =>
        !left.Equals(right);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are equal.
    /// </summary>
    /// <param name="left">The left hand side operand.</param>
    /// <param name="right">The right hand side operand.</param>
    /// <returns>A value that indicates whether the time and object are equal.</returns>
    public static bool operator ==(object? left, Iso8601Time right) =>
        right.Equals(left);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are not equal.
    /// </summary>
    /// <param name="left">The left hand side operand.</param>
    /// <param name="right">The right hand side operand.</param>
    /// <returns>A value that indicates whether the time and object are not equal.</returns>
    public static bool operator !=(object? left, Iso8601Time right) =>
        !right.Equals(left);
}
