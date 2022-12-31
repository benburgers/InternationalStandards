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
    /// <param name="dateOnly">A date-only value.</param>
    /// <param name="simple">Indicates whether the date is a simple representation.</param>
    public Iso8601CalendarDate(DateOnly dateOnly, bool simple = false)
    {
        this.Year = dateOnly.Year;
        this.Month = (ushort)dateOnly.Month;
        this.Day = (ushort)dateOnly.Day;
        this.Simple = simple;
    }

    /// <inheritdoc />
    public DateOnly ToDate() => new(this.Year, this.Month ?? 1, this.Day ?? 1, Calendar);

    /// <summary>
    /// Converts <paramref name="dateOnly" /> to a <see cref="Iso8601CalendarDate" />.
    /// </summary>
    /// <param name="dateOnly">The date-only value to convert to an <see cref="Iso8601CalendarDate" />.</param>
    public static explicit operator Iso8601CalendarDate(DateOnly dateOnly) =>
        new(dateOnly);

    /// <summary>
    /// Converts <paramref name="calendarDate" /> to a <see cref="DateOnly" />.
    /// </summary>
    /// <param name="calendarDate">The calendar date to convert to a <see cref="DateOnly" />.</param>
    public static explicit operator DateOnly(Iso8601CalendarDate calendarDate) =>
        calendarDate.ToDate();
}
