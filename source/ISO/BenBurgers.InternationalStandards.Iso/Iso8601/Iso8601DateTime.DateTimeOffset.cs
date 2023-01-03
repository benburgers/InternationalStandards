/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601DateTime
{
    /// <summary>
    /// Converts <paramref name="dateTimeOffset" /> to an ISO 8601 Date and Time.
    /// </summary>
    /// <param name="dateTimeOffset">The date, time and time zone offset.</param>
    /// <returns>The ISO 8601 Date and Time combination.</returns>
    public static Iso8601DateTime FromDateTimeOffset(DateTimeOffset dateTimeOffset) =>
        new((Iso8601CalendarDate)dateTimeOffset, (Iso8601Time)dateTimeOffset);

    /// <inheritdoc />
    public DateTimeOffset ToDateTimeOffset()
    {
        var offset = this.Time?.UtcOffset ?? TimeSpan.Zero;
        var dateTime = this.ToDateTime() + offset;
        return new(dateTime, offset);
    }


    /// <summary>
    /// Converts <paramref name="dateTimeOffset" /> to an ISO 8601 Date and Time combination.
    /// </summary>
    /// <param name="dateTimeOffset">The date, time and time zone offset.</param>
    public static explicit operator Iso8601DateTime(DateTimeOffset dateTimeOffset) =>
        FromDateTimeOffset(dateTimeOffset);

    /// <summary>
    /// Converts <paramref name="dateTime" /> to a <see cref="DateTimeOffset" />.
    /// </summary>
    /// <param name="dateTime">The ISO 8601 Date and Time.</param>
    public static explicit operator DateTimeOffset(Iso8601DateTime dateTime) =>
        dateTime.ToDateTimeOffset();
}
