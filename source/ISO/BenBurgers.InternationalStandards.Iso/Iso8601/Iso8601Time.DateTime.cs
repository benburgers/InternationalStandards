/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601Time
{
    /// <summary>
    /// Converts <paramref name="dateTime" /> to a <see cref="Iso8601Time" />.
    /// </summary>
    /// <param name="dateTime">The date and time to convert.</param>
    /// <remarks>
    ///     <strong>
    ///         The date component will be truncated, which may lead to data loss.<br />
    ///         If you wish to preserve the date value, please use the ISO 8601 Date and Time combination.
    ///     </strong>
    /// </remarks>
    /// <returns>An ISO 8601 Time.</returns>
    public static Iso8601Time FromDateTime(DateTime dateTime) =>
        dateTime.Kind switch
        {
            DateTimeKind.Local =>
                new(
                    (byte)dateTime.Hour,
                    (byte)dateTime.Minute,
                    (byte)dateTime.Second,
                    dateTime.Millisecond / 1_000.0m
#if NET7_0_OR_GREATER
                    + dateTime.Microsecond / 1_000_000.0m
                    + dateTime.Nanosecond / 1_000_000_000.0m
#endif
                    ,
                    TimeZoneInfo.Local.BaseUtcOffset),
            DateTimeKind.Utc =>
                new(
                    (byte)dateTime.Hour,
                    (byte)dateTime.Minute,
                    (byte)dateTime.Second,
                    dateTime.Millisecond / 1_000.0m
#if NET7_0_OR_GREATER
                    + dateTime.Microsecond / 1_000_000.0m
                    + dateTime.Nanosecond / 1_000_000_000.0m
#endif
                    ,
                    TimeSpan.Zero),
            _ =>
                new(
                    (byte)dateTime.Hour,
                    (byte)dateTime.Minute,
                    (byte)dateTime.Second,
                    dateTime.Millisecond / 1_000.0m
#if NET7_0_OR_GREATER
                    + dateTime.Microsecond / 1_000_000.0m
                    + dateTime.Nanosecond / 1_000_000_000.0m
#endif

                    )
        };

    /// <summary>
    /// Converts the ISO 8601 Time to a <see cref="DateTime" />.
    /// </summary>
    /// <param name="kind">The date and time kind.</param>
    /// <returns>The date and time.</returns>
    public DateTime ToDateTime(DateTimeKind kind = DateTimeKind.Unspecified)
    {
        var date = DateTime.UtcNow.Date;
        if (kind == DateTimeKind.Local)
            date -= TimeZoneInfo.Local.BaseUtcOffset; // invert local UTC offset to compensate
        var millisecond = (int)Math.Truncate((this.Fraction ?? 0.0m) * 1_000.0m);
#if NET7_0_OR_GREATER
        var microsecond =
            millisecond > 0
                ? (int)((int)Math.Truncate((this.Fraction ?? 0.0m) * 1_000_000.0m) - millisecond * 1_000.0m)
                : (int)Math.Truncate((this.Fraction ?? 0.0m) * 1_000_000.0m);
#endif
        return DateTime.SpecifyKind(new DateTime(
            date.Year,
            date.Month,
            date.Day,
            this.Hour,
            this.Minute ?? 0,
            this.Second ?? 0,
            millisecond,
#if NET7_0_OR_GREATER
            microsecond,
#endif
            DateTimeKind.Unspecified)
            + (kind, this.UtcOffset) switch
            {
                (DateTimeKind.Local, { } utcOffset) => -utcOffset + TimeZoneInfo.Local.BaseUtcOffset,
                (DateTimeKind.Local, _) => TimeZoneInfo.Local.BaseUtcOffset,
                (DateTimeKind.Utc, { } utcOffset) => -utcOffset,
                (_, _) => TimeSpan.Zero
            }, kind);
    }

    /// <summary>
    /// Converts <paramref name="dateTime" /> to an <see cref="Iso8601Time" />.
    /// </summary>
    /// <param name="dateTime">The date and time.</param>
    public static explicit operator Iso8601Time(DateTime dateTime) =>
        FromDateTime(dateTime);

    /// <summary>
    /// Converts <paramref name="time" /> to a <see cref="DateTime" />.
    /// </summary>
    /// <param name="time">The time.</param>
    public static explicit operator DateTime(Iso8601Time time) =>
        time.ToDateTime();
}