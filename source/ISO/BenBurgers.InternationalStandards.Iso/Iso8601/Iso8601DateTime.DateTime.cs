/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601DateTime
{
    /// <summary>
    /// Converts <paramref name="dateTime" /> to an <see cref="Iso8601DateTime" />.
    /// </summary>
    /// <param name="dateTime">The date and time to convert.</param>
    /// <returns>An <see cref="Iso8601DateTime" />.</returns>
    public static Iso8601DateTime FromDateTime(DateTime dateTime) =>
        new((Iso8601CalendarDate)dateTime, (Iso8601Time)dateTime);

    /// <inheritdoc />
    public DateTime ToDateTime() => this.ToDateTime(DateTimeKind.Unspecified);

    /// <inheritdoc />
    public DateTime ToDateTime(DateTimeKind kind = DateTimeKind.Unspecified)
    {
        var date = this.Date?.ToDate() ?? new DateOnly();
        var time = this.Time?.ToTime() ?? new TimeOnly();
        return date.ToDateTime(time, kind);
    }

    /// <summary>
    /// Converts <paramref name="dateTime" /> to an ISO 8601 Date and Time combination.
    /// </summary>
    /// <param name="dateTime">The date and time.</param>
    public static explicit operator Iso8601DateTime(DateTime dateTime) =>
        FromDateTime(dateTime);

    /// <summary>
    /// Converts <paramref name="dateTime" /> to an ISO 8601 Date and Time combination.
    /// </summary>
    /// <param name="dateTime">The date and time.</param>
    public static explicit operator DateTime(Iso8601DateTime dateTime) =>
        dateTime.ToDateTime();
}
