/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601.Exceptions;
using System.Globalization;

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

/// <summary>
/// An ISO 8601 Ordinal Date as defined by <a href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO 8601</a>.
/// </summary>
public readonly partial struct Iso8601OrdinalDate : IIso8601DateValue
{
    private static readonly GregorianCalendar Calendar = new();

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601OrdinalDate" />.
    /// </summary>
    public Iso8601OrdinalDate()
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        this.Year = today.Year;
        this.DayOfYear = (ushort)today.DayOfYear;
        this.Simple = false;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601OrdinalDate" />.
    /// </summary>
    /// <param name="year">The Gregorian year.</param>
    /// <param name="dayOfYear">The day of the year, ranging from 1 through 365 (366 in leap years).</param>
    /// <param name="simple">Indicates whether the ISO 8601 Ordinal Date has a simple representation.</param>
    /// <exception cref="Iso8601OrdinalDateOutOfRangeException">
    /// An <see cref="Iso8601OrdinalDateOutOfRangeException" /> is thrown if the <paramref name="dayOfYear" /> is not a day in the specified <paramref name="year" />.
    /// </exception>
    public Iso8601OrdinalDate(int year, ushort dayOfYear, bool simple = false)
    {
        if (Calendar.GetDaysInYear(year) < dayOfYear)
            throw new Iso8601OrdinalDateOutOfRangeException();
        this.Year = year;
        this.DayOfYear = dayOfYear;
        this.Simple = simple;
    }

    /// <summary>
    /// Gets the Gregorian year component of the ISO 8601 Ordinal Date.
    /// </summary>
    public int Year { get; }

    /// <summary>
    /// Gets the day of the year of the ISO 8601 Ordinal Date, ranging from 1 through 365 (366 in leap years).
    /// </summary>
    public ushort DayOfYear { get; }

    /// <summary>
    /// Gets a value that indicates whether the ISO 8601 Ordinal Date has a simple representation.
    /// </summary>
    public bool Simple { get; }
}
