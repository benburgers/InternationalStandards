/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601Time
{
    /// <summary>
    /// Converts <paramref name="time" /> to a <see cref="Iso8601Time" />.
    /// </summary>
    /// <param name="time">The time to convert.</param>
    /// <param name="utcOffset">The UTC offset.</param>
    /// <returns>The ISO 8601 time.</returns>
    public static Iso8601Time FromTime(
        TimeOnly time,
        TimeSpan? utcOffset = null) =>
#if NET6_0
        utcOffset is { }
            ? new Iso8601Time(
                (byte)time.Hour,
                (byte)time.Minute,
                (byte)time.Second,
                time.Millisecond / 1000.0m,
                utcOffset.Value)
            : new Iso8601Time(
                (byte)time.Hour,
                (byte)time.Minute,
                (byte)time.Second,
                time.Millisecond / 1000.0m);
#endif
#if NET7_0_OR_GREATER
        utcOffset is { }
            ? new Iso8601Time(
                (byte)time.Hour,
                (byte)time.Minute,
                (byte)time.Second,
                time.Millisecond / 1000.0m + time.Microsecond / 10000.0m + time.Nanosecond / 100000.0m,
                utcOffset.Value)
            : new Iso8601Time(
                (byte)time.Hour,
                (byte)time.Minute,
                (byte)time.Second,
                time.Millisecond / 1000.0m + time.Microsecond / 10000.0m + time.Nanosecond / 100000.0m);
#endif

    /// <inheritdoc />
    public TimeOnly ToTime(TimeSpan? utcOffset = null) =>
        new TimeOnly(
            this.Hour,
            this.Minute ?? 0,
            this.Second ?? 0,
            (int)((this.Fraction ?? 0.0m) * 1000.0m))
        .Add((this.UtcOffset, utcOffset) switch
        {
            (null, null) => TimeSpan.Zero,
            (null, { } o2) => o2,
            ({ } o1, null) => -o1,
            ({ } o1, { } o2) => -o1 + o2
        });

    /// <summary>
    /// Converts <paramref name="timeOnly" /> to an <see cref="Iso8601Time" />.
    /// </summary>
    /// <param name="timeOnly">The time to convert.</param>
    public static explicit operator Iso8601Time(TimeOnly timeOnly) =>
        FromTime(timeOnly);

    /// <summary>
    /// Converts <paramref name="time" /> to a <see cref="TimeOnly" />.
    /// </summary>
    /// <param name="time">The time to convert.</param>
    public static explicit operator TimeOnly(Iso8601Time time) =>
        time.ToTime();
}
