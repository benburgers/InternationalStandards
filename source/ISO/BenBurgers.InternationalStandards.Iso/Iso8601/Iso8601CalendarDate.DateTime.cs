/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601CalendarDate
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601CalendarDate" />.
    /// </summary>
    /// <param name="dateTime">A date and time value.</param>
    /// <param name="simple">Indicates whether the date has a simple representation.</param>
    /// <remarks>
    ///     <strong>
    ///         The time component will be truncated, which may result in loss of data.<br />
    ///         If you wish to include the time, please use the ISO 8601 Date and Time combination.
    ///     </strong>
    /// </remarks>
    public static Iso8601CalendarDate FromDateTime(DateTime dateTime, bool simple = false)
    {
        var year = dateTime.Year;
        var month = (ushort)dateTime.Month;
        var day = (ushort)dateTime.Day;
        return new Iso8601CalendarDate(year, month, day, simple);
    }

    /// <inheritdoc />
    public DateTime ToDateTime() => new(this.Year, this.Month ?? 1, this.Day ?? 1);

    /// <summary>
    /// Converts <paramref name="dateTime" /> to a <see cref="Iso8601CalendarDate" />
    /// </summary>
    /// <param name="dateTime">The date and time value to convert to an <see cref="Iso8601CalendarDate" />.</param>
    /// <remarks>
    ///     <strong>
    ///         The time component will be truncated, which may lead to a loss of data.<br />
    ///         If you wish to include the time, please use the ISO 8601 Date and Time combination.
    ///     </strong>
    /// </remarks>
    public static explicit operator Iso8601CalendarDate(DateTime dateTime) =>
        FromDateTime(dateTime);

    /// <summary>
    /// Converts <paramref name="calendarDate" /> to a <see cref="DateTime" />.
    /// </summary>
    /// <param name="calendarDate">The calendar date to convert to a <see cref="DateTime" />.</param>
    public static explicit operator DateTime(Iso8601CalendarDate calendarDate) =>
        calendarDate.ToDateTime();
}
