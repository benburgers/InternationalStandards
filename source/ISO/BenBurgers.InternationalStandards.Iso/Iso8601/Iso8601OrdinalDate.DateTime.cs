/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601OrdinalDate
{
    /// <summary>
    /// Converts a <paramref name="dateTime" /> to an <see cref="Iso8601OrdinalDate" />.
    /// </summary>
    /// <param name="dateTime">The date and time to convert.</param>
    /// <param name="simple">Indicates whether the ISO 8601 Ordinal Date has a simple representation.</param>
    /// <remarks>
    ///     <strong>
    ///         The time component is truncated, which may lead to data loss.<br />
    ///         If you wish to preserve the time, please use the ISO 8601 Date and Time combination.
    ///     </strong>
    /// </remarks>
    /// <returns>The ISO 8601 Ordinal Date.</returns>
    public static Iso8601OrdinalDate FromDateTime(DateTime dateTime, bool simple = false)
    {
        var year = dateTime.Year;
        var dayOfYear = (ushort)dateTime.DayOfYear;
        return new Iso8601OrdinalDate(year, dayOfYear, simple);
    }

    /// <inheritdoc />
    public DateTime ToDateTime() => new DateTime(this.Year, 1, 1, Calendar).AddDays(this.DayOfYear - 1);

    /// <summary>
    /// Converts a <paramref name="dateTime" /> to an <see cref="Iso8601OrdinalDate" />.
    /// </summary>
    /// <param name="dateTime">The date and time to convert.</param>
    /// <remarks>
    ///     <strong>
    ///         The time component is truncated, which may lead to data loss.<br />
    ///         If you wish to preserve the time, please use the ISO 8601 Date and Time combination.
    ///     </strong>
    /// </remarks>
    public static explicit operator Iso8601OrdinalDate(DateTime dateTime) =>
        FromDateTime(dateTime);

    /// <summary>
    /// Converts an <paramref name="ordinalDate" /> to a <see cref="DateTime" />.
    /// </summary>
    /// <param name="ordinalDate">The ordinal date to convert.</param>
    public static explicit operator DateTime(Iso8601OrdinalDate ordinalDate) =>
        ordinalDate.ToDateTime();
}
