/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601.Exceptions;
using System.Globalization;

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

/// <summary>
/// An ISO 8601 Calendar Date as defined by <a href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO 8601</a>.
/// </summary>
public readonly partial struct Iso8601CalendarDate : IIso8601DateValue
{
    private static readonly GregorianCalendar Calendar = new();

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601CalendarDate" />.
    /// </summary>
    public Iso8601CalendarDate()
    {
        var date = DateOnly.FromDateTime(DateTime.Now);
        this.Year = date.Year;
        this.Month = (ushort)date.Month;
        this.Day = (ushort)date.Day;
        this.Simple = false;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601CalendarDate" />.
    /// </summary>
    /// <param name="year">The Gregorian year.</param>
    /// <param name="simple">Indicates whether the date has a simple representation.</param>
    public Iso8601CalendarDate(int year, bool simple = false)
    {
        this.Year = year;
        this.Month = null;
        this.Day = null;
        this.Simple = simple;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601CalendarDate" />.
    /// </summary>
    /// <param name="year">The Gregorian year.</param>
    /// <param name="month">The month (1 through 12).</param>
    /// <param name="simple">Indicates whether the date has a simple representation.</param>
    /// <exception cref="Iso8601CalendarDateOutOfRangeException">
    /// An <see cref="Iso8601CalendarDateOutOfRangeException" /> is thrown if any of the components is out of the accepted range for ISO 8601 Calendar Dates.
    /// </exception>
    public Iso8601CalendarDate(int year, ushort month, bool simple = false)
    {
        this.Year = year;
        this.Month = month;
        this.Day = null;
        this.Simple = simple;
        this.ValidateMonth();
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601CalendarDate" />.
    /// </summary>
    /// <param name="year">The Gregorian year.</param>
    /// <param name="month">The month (1 through 12).</param>
    /// <param name="day">The day (1 through the number of days in the month).</param>
    /// <param name="simple">Indicates whether the date has a simple representation.</param>
    /// <exception cref="Iso8601CalendarDateOutOfRangeException">
    /// An <see cref="Iso8601CalendarDateOutOfRangeException" /> is thrown if any of the components is out of the accepted range for ISO 8601 Calendar Dates.
    /// </exception>
    public Iso8601CalendarDate(int year, ushort month, ushort day, bool simple = false)
    {
        this.Year = year;
        this.Month = month;
        this.Day = day;
        this.Simple = simple;
        this.ValidateMonth();
        this.ValidateDay();
    }

    /// <summary>
    /// Gets the year component.
    /// </summary>
    public int Year { get; }

    /// <summary>
    /// Gets the month component.
    /// </summary>
    public ushort? Month { get; }

    /// <summary>
    /// Gets the day component.
    /// </summary>
    public ushort? Day { get; }

    /// <summary>
    /// Gets a value that indicates whether the date is simple.
    /// </summary>
    public bool Simple { get; }

    private void ValidateDay()
    {
        if (this.Month is not { } month)
            throw new Iso8601CalendarDateOutOfRangeException(nameof(month));
        if (this.Day is not { } day)
            throw new Iso8601CalendarDateOutOfRangeException(nameof(day));
        if (day == 0 || Calendar.GetDaysInMonth(this.Year, month) < day)
            throw new Iso8601CalendarDateOutOfRangeException(nameof(day));
    }

    private void ValidateMonth()
    {
        if (this.Month is not { } month || this.Month is 0 or > 12)
            throw new Iso8601CalendarDateOutOfRangeException(nameof(month));
    }
}
