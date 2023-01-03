/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601Time
{
    /// <summary>
    /// Converts <paramref name="dateTimeOffset" /> to an <see cref="Iso8601Time" />.
    /// </summary>
    /// <param name="dateTimeOffset">The date, time and time zone offset.</param>
    /// <remarks>
    ///     <strong>
    ///         The date component will be truncated, which may lead to loss of data.<br />
    ///         If you wish to preserve the date, please use the ISO 8601 Date and Time combination.
    ///     </strong>
    /// </remarks>
    /// <returns>The ISO 8601 Time.</returns>
    public static Iso8601Time FromDateTimeOffset(DateTimeOffset dateTimeOffset) =>
        new(
            (byte)dateTimeOffset.Hour,
            (byte)dateTimeOffset.Minute,
            (byte)dateTimeOffset.Second,
            dateTimeOffset.Millisecond / 1_000.0m
#if NET7_0_OR_GREATER
            + dateTimeOffset.Microsecond / 1_000_000.0m
            + dateTimeOffset.Nanosecond / 1_000_000_000.0m
#endif
            ,
            dateTimeOffset.Offset);

    /// <summary>
    /// Converts the ISO 8601 Time to a <see cref="DateTimeOffset" />.
    /// </summary>
    /// <returns>The ISO 8601 Time as a <see cref="DateTimeOffset" />.</returns>
    public DateTimeOffset ToDateTimeOffset()
    {
        var utcToday = DateTimeOffset.UtcNow.Date;
        var millisecond = (int)Math.Truncate((this.Fraction ?? 0.0m) * 1_000.0m);
#if NET7_0_OR_GREATER
        var microsecond =
            millisecond > 0
                ? (int)((int)Math.Truncate((this.Fraction ?? 0.0m) * 1_000_000.0m) - millisecond * 1_000.0m)
                : (int)Math.Truncate((this.Fraction ?? 0.0m) * 1_000_000.0m);
#endif
        return new DateTimeOffset(
            utcToday.Year,
            utcToday.Month,
            utcToday.Day,
            this.Hour,
            this.Minute ?? 0,
            this.Second ?? 0,
            millisecond,
#if NET7_0_OR_GREATER
            microsecond,
#endif
            this.UtcOffset ?? TimeSpan.Zero);
    }

    /// <summary>
    /// Converts <paramref name="dateTimeOffset" /> to an ISO 8601 Time.
    /// </summary>
    /// <param name="dateTimeOffset">The date, time and time zone offset.</param>
    /// <remarks>
    ///     <strong>
    ///         The date component will be truncated, which may lead to loss of data.<br />
    ///         If you wish to preserve the date, please use the ISO 8601 Date and Time combination.
    ///     </strong>
    /// </remarks>
    public static explicit operator Iso8601Time(DateTimeOffset dateTimeOffset) =>
        FromDateTimeOffset(dateTimeOffset);

    /// <summary>
    /// Converts <paramref name="time" /> to a <see cref="DateTimeOffset" />.
    /// </summary>
    /// <param name="time">The ISO 8601 Time.</param>
    public static explicit operator DateTimeOffset(Iso8601Time time) =>
        time.ToDateTimeOffset();
}
