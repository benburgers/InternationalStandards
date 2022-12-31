/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601.Exceptions;

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

/// <summary>
/// An ISO 8601 Date and Time combination.
/// </summary>
public readonly partial struct Iso8601DateTime : IIso8601DateValue, IIso8601TimeValue
{
    private const char DateTimeSeparator = 'T';

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601DateTime" />.
    /// </summary>
    /// <param name="date">The date component of the ISO 8601 Date and Time.</param>
    public Iso8601DateTime(Iso8601CalendarDate date)
    {
        this.Date = date;
        this.Time = null;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601DateTime" />.
    /// </summary>
    /// <param name="time">The time component of the ISO 8601 Date and Time.</param>
    public Iso8601DateTime(Iso8601Time time)
    {
        this.Date = null;
        this.Time = time;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601DateTime" />.
    /// </summary>
    /// <param name="date">The date component of the ISO 8601 Date and Time.</param>
    /// <param name="time">The time component of the ISO 8601 Date and Time.</param>
    public Iso8601DateTime(Iso8601CalendarDate date, Iso8601Time time)
    {
        this.Date = date;
        this.Time = time;
    }

    /// <summary>
    /// Gets the date component of the ISO 8601 Date and Time.
    /// </summary>
    public Iso8601CalendarDate? Date { get; }

    /// <summary>
    /// Gets the time component of the ISO 8601 Date and Time.
    /// </summary>
    public Iso8601Time? Time { get; }

    /// <inheritdoc />
    /// <exception cref="Iso8601DateComponentMissingException">
    /// An <see cref="Iso8601DateComponentMissingException" /> is thrown if the date component is not specified.
    /// </exception>
    public DateOnly ToDate()
    {
        if (this.Date is not { } date)
            throw new Iso8601DateComponentMissingException();
        return date.ToDate();
    }

    /// <inheritdoc />
    /// <exception cref="Iso8601TimeComponentMissingException">
    /// An <see cref="Iso8601TimeComponentMissingException" /> is thrown if the ISO 8601 value does not have a time component.
    /// </exception>
    public TimeOnly ToTime(TimeSpan? utcOffset = null)
    {
        if (this.Time is not { } time)
            throw new Iso8601TimeComponentMissingException();
        return time.ToTime();
    }
}
