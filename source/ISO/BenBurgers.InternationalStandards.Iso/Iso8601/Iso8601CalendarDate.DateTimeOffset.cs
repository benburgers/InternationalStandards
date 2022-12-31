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
    /// <param name="dateTimeOffset">The date, time and time zone offset.</param>
    /// <param name="simple">Indicates whether the date has a simple representation.</param>
    /// <remarks>
    ///     <strong>
    ///         The time and time zone components will be truncated, which may result in loss of data.<br />
    ///         If you wish to include the time and time zone, please use the ISO 8601 Date and Time combination.
    ///     </strong>
    /// </remarks>
    public static Iso8601CalendarDate FromDateTimeOffset(DateTimeOffset dateTimeOffset, bool simple = false)
    {
        var year = dateTimeOffset.Year;
        var month = (ushort)dateTimeOffset.Month;
        var day = (ushort)dateTimeOffset.Day;
        return new Iso8601CalendarDate(year, month, day, simple);
    }

    /// <inheritdoc />
    public DateTimeOffset ToDateTimeOffset() => new(this.ToDateTime());

    /// <summary>
    /// Converts <paramref name="dateTimeOffset" /> to a <see cref="Iso8601CalendarDate" />.
    /// </summary>
    /// <param name="dateTimeOffset">The date, time and time zone offset.</param>
    /// <remarks>
    ///     <strong>
    ///         The time and time zone components will be truncated, which may lead to loss of data.<br />
    ///         If you wish to include the time and time zone, please use the ISO 8601 Date and Time combination.
    ///     </strong>
    /// </remarks>
    public static explicit operator Iso8601CalendarDate(DateTimeOffset dateTimeOffset) =>
        FromDateTimeOffset(dateTimeOffset);

    /// <summary>
    /// Converts <paramref name="calendarDate" /> to a <see cref="DateTimeOffset" />.
    /// </summary>
    /// <param name="calendarDate">The ISO 8601 Calendar Date.</param>
    public static explicit operator DateTimeOffset(Iso8601CalendarDate calendarDate) =>
        calendarDate.ToDateTimeOffset();
}
