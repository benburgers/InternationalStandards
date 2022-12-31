/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601OrdinalDate
{
    /// <summary>
    /// Converts <paramref name="dateOnly" /> to an <see cref="Iso8601OrdinalDate" />.
    /// </summary>
    /// <param name="dateOnly">The date.</param>
    /// <param name="simple">Indicates whether the ISO 8601 Ordinal Date has a simple representation.</param>
    /// <returns>The ISO 8601 Ordinal Date.</returns>
    public static Iso8601OrdinalDate FromDate(DateOnly dateOnly, bool simple = false)
    {
        var year = dateOnly.Year;
        var dayOfYear = (ushort)dateOnly.DayOfYear;
        return new Iso8601OrdinalDate(year, dayOfYear, simple);
    }

    /// <inheritdoc />
    public DateOnly ToDate() => new DateOnly(this.Year, 1, 1, Calendar).AddDays(this.DayOfYear - 1);

    /// <summary>
    /// Converts <paramref name="dateOnly" /> to an <see cref="Iso8601OrdinalDate" />.
    /// </summary>
    /// <param name="dateOnly">The date to convert.</param>
    public static explicit operator Iso8601OrdinalDate(DateOnly dateOnly) =>
        FromDate(dateOnly);

    /// <summary>
    /// Converts <paramref name="ordinalDate" /> to a <see cref="DateOnly" />.
    /// </summary>
    /// <param name="ordinalDate">The ordinal date to convert.</param>
    public static explicit operator DateOnly(Iso8601OrdinalDate ordinalDate) =>
        ordinalDate.ToDate();
}
