/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601DateTime
{
    /// <summary>
    /// Parses an ISO 8601 Date and Time from <paramref name="value" />.
    /// </summary>
    /// <param name="value">The ISO 8601 Date and Time string representation.</param>
    /// <returns>The ISO 8601 Date and Time.</returns>
    /// <exception cref="Iso8601ParseException">
    /// An <see cref="Iso8601ParseException" /> is thrown if <paramref name="value" /> cannot be parsed.
    /// </exception>
    public static Iso8601DateTime Parse(string value)
    {
        var components = value.Split(DateTimeSeparator);
        return components.Length switch
        {
            0 => throw new Iso8601ParseException(0, "No ISO 8601 date or time component recognized."),
            1 => Iso8601CalendarDate.TryParse(components[0], out var calendarDate)
                    ? new Iso8601DateTime(calendarDate.Value)
                    : Iso8601Time.TryParse(components[0], out var time)
                        ? new Iso8601DateTime(time.Value)
                        : throw new Iso8601ParseException(0, "No ISO 8601 date or time component recognized."),
            2 => new Iso8601DateTime(Iso8601CalendarDate.Parse(components[0]), Iso8601Time.Parse(components[1])),
            _ => throw new Iso8601ParseException(0, "Invalid ISO 8601 Date and Time format.")
        };
    }

    /// <summary>
    /// Attempts to parse an ISO 8601 Date and Time from <paramref name="value" />.
    /// </summary>
    /// <param name="value">The ISO 8601 Date and Time string representation.</param>
    /// <param name="result">The ISO 8601 Date and Time.</param>
    /// <returns>
    /// A value that indicates whether the ISO 8601 Date and Time was parsed successfully from <paramref name="value" />.
    /// </returns>
    public static bool TryParse(string value, [NotNullWhen(true)] out Iso8601DateTime? result)
    {
        try
        {
            result = Parse(value);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }
}
