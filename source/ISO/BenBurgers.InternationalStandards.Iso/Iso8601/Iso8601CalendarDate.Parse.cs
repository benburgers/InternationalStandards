/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601CalendarDate
{
    private const char Separator = '-';

    /// <summary>
    /// Parses an ISO 8601 Calendar Date from <paramref name="value" />.
    /// </summary>
    /// <param name="value">The string value that contains a representation of an ISO 8601 Calendar Date.</param>
    /// <returns>The ISO 8601 Calendar Date.</returns>
    /// <exception cref="Iso8601ParseException">
    /// An <see cref="Iso8601ParseException" /> is thrown if <paramref name="value" /> has a syntax error.
    /// </exception>
    public static Iso8601CalendarDate Parse(string value)
    {
        var simple = false;
        var yearBuilder = new StringBuilder();
        var monthBuilder = new StringBuilder();
        var dayBuilder = new StringBuilder();

        for (var i = 0; i < value.Length; i++)
        {
            switch (value[i], yearBuilder, monthBuilder, dayBuilder, simple)
            {
                // Year
                case ({ } c, { Length: >= 0 and < 4 }, _, _, _) when char.IsDigit(c):
                    yearBuilder.Append(c);
                    break;

                // Month
                case ({ } c, { Length: 4 }, { Length: 0 }, _, _) when c == Separator && value[i - 1] != Separator:
                    // simple = false;
                    break;
                case ({ } c, { Length: 4 }, { Length: 0 }, _, _) when char.IsDigit(c) && value[i - 1] == Separator:
                    // simple = false;
                    monthBuilder.Append(c);
                    break;
                case ({ } c, { Length: 4 }, { Length: 0 }, _, _) when char.IsDigit(c):
                    simple = true;
                    monthBuilder.Append(c);
                    break;
                case ({ } c, { Length: 4 }, { Length: >= 1 and < 2 }, _, _) when char.IsDigit(c):
                    monthBuilder.Append(c);
                    break;

                // Day
                case ({ } c, { Length: 4 }, { Length: 2 }, { Length: 0 }, _) when c == Separator && value[i - 1] != Separator:
                    break;
                case ({ } c, { Length: 4 }, { Length: 2 }, { Length: 0 }, _) when char.IsDigit(c) && value[i - 1] == Separator:
                    // simple = false;
                    dayBuilder.Append(c);
                    break;
                case ({ } c, { Length: 4 }, { Length: 2 }, { Length: 0 }, _) when char.IsDigit(c):
                    simple = true;
                    dayBuilder.Append(c);
                    break;
                case ({ } c, { Length: 4 }, { Length: 2 }, { Length: >= 1 and < 2 }, _) when char.IsDigit(c):
                    dayBuilder.Append(c);
                    break;

                // Errors
                case ({ } c, { Length: >= 0 and < 4 }, _, _, _):
                    throw new Iso8601ParseException(i, "Expected year.");
                case ({ } c, { Length: 4 }, { Length: >= 0 and < 2 }, _, _):
                    throw new Iso8601ParseException(i, "Expected date separator or month.");
                case ({ } c, { Length: 4 }, { Length: 2 }, _, _):
                    throw new Iso8601ParseException(i, "Expected date separator or day.");
                default:
                    throw new Iso8601ParseException(i, "Unexpected token.");
            }
        }

        var year = int.Parse(yearBuilder.ToString());
        ushort? monthResult =
            monthBuilder.Length > 0
                ? ushort.Parse(monthBuilder.ToString())
                : null;
        ushort? dayResult =
            dayBuilder.Length > 0
                ? ushort.Parse(dayBuilder.ToString())
                : null;

        return (year, monthResult, dayResult) switch
        {
            ({ }, { } month, { } day) => new Iso8601CalendarDate(year, month, day, simple),
            ({ }, { } month, null) => new Iso8601CalendarDate(year, month, simple),
            ({ }, null, null) => new Iso8601CalendarDate(year, simple),
            _ => new Iso8601CalendarDate()
        };
    }

    /// <summary>
    /// Attempts to parse an ISO 8601 Calendar Date from <paramref name="value" />.
    /// </summary>
    /// <param name="value">The string representation of the ISO 8601 Calendar Date.</param>
    /// <param name="result">The ISO 8601 Calendar Date.</param>
    /// <returns>A value that indicates whether the ISO 8601 Calendar Date was successfully parsed.</returns>
    public static bool TryParse(string value, [NotNullWhen(true)] out Iso8601CalendarDate? result)
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
