/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601OrdinalDate
{
    /// <summary>
    /// Converts <paramref name="dateTimeOffset" /> to a <see cref="Iso8601OrdinalDate" />.
    /// </summary>
    /// <param name="dateTimeOffset">The date, time and time zone UTC offset.</param>
    /// <param name="simple">Indicates whether the ISO 8601 Ordinal Date has a simple representation.</param>
    /// <remarks>
    ///     <strong>
    ///         The time and time zone components are truncated, which may lead to data loss.<br />
    ///         If you wish to preserve the time and time zone, please use the ISO 8601 Date and Time combination.
    ///     </strong>
    /// </remarks>
    /// <returns>The ISO 8601 Ordinal Date.</returns>
    public static Iso8601OrdinalDate FromDateTimeOffset(DateTimeOffset dateTimeOffset, bool simple = false) =>
        FromDateTime(dateTimeOffset.DateTime, simple);

    /// <inheritdoc />
    public DateTimeOffset ToDateTimeOffset() => new(this.ToDateTime());

    /// <summary>
    /// Converts <paramref name="dateTimeOffset" /> to a <see cref="Iso8601OrdinalDate" />.
    /// </summary>
    /// <param name="dateTimeOffset">The date, time and time zone UTC offset.</param>
    /// <remarks>
    ///     <strong>
    ///         The time and time zone components are truncated, which may lead to data loss.<br />
    ///         If you wish to preserve the time and time zone, please use the ISO 8601 Date and Time combination.
    ///     </strong>
    /// </remarks>
    public static explicit operator Iso8601OrdinalDate(DateTimeOffset dateTimeOffset) =>
        FromDateTimeOffset(dateTimeOffset);

    /// <summary>
    /// Converts <paramref name="ordinalDate" /> to a <see cref="DateTimeOffset" />.
    /// </summary>
    /// <param name="ordinalDate">The ISO 8601 Ordinal Date.</param>
    public static explicit operator DateTimeOffset(Iso8601OrdinalDate ordinalDate) =>
        ordinalDate.ToDateTimeOffset();
}
