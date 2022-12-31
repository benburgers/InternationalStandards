/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601OrdinalDate
{
    private const char Separator = '-';

    /// <summary>
    /// Parses an ISO 8601 Ordinal Date from <paramref name="value" />.
    /// </summary>
    /// <param name="value">The string value that contains a representation of an ISO 8601 Ordinal Date.</param>
    /// <returns>The ISO 8601 Ordinal Date.</returns>
    /// <exception cref="Iso8601ParseException">
    /// An <see cref="Iso8601ParseException" /> is thrown if <paramref name="value" /> has a syntax error.
    /// </exception>
    public static Iso8601OrdinalDate Parse(string value)
    {
        var simple = false;
        var yearBuilder = new StringBuilder();
        var dayOfYearBuilder = new StringBuilder();

        for (var i = 0; i < value.Length; i++)
        {
            switch (value[i], yearBuilder, dayOfYearBuilder)
            {
                // Year
                case ({ } c, { Length: >= 0 and < 4 }, _) when char.IsDigit(c):
                    yearBuilder.Append(c);
                    break;

                // Day of Year
                case ({ } c, { Length: 4 }, { Length: 0 }) when c == Separator && value[i - 1] != Separator:
                    // simple = false;
                    break;
                case ({ } c, { Length: 4 }, { Length: 0 }) when char.IsDigit(c) && value[i - 1] == Separator:
                    // simple = false;
                    dayOfYearBuilder.Append(c);
                    break;
                case ({ } c, { Length: 4 }, { Length: 0 }) when char.IsDigit(c):
                    simple = true;
                    dayOfYearBuilder.Append(c);
                    break;
                case ({ } c, { Length: 4 }, { Length: >= 1 and <= 3 }) when char.IsDigit(c):
                    dayOfYearBuilder.Append(c);
                    break;

                // Errors
                default:
                    throw new Iso8601ParseException(i, "Unexpected token.");
            }
        }

        var year = int.Parse(yearBuilder.ToString());
        var dayOfYear = ushort.Parse(dayOfYearBuilder.ToString());
        return new(year, dayOfYear, simple);
    }

    /// <summary>
    /// Attempts to parse an ISO 8601 Ordinal Date from <paramref name="value" />.
    /// </summary>
    /// <param name="value">A string value that contains a representation of an ISO 8601 Ordinal Date.</param>
    /// <param name="result">The parsed ISO 8601 Ordinal Date.</param>
    /// <returns>A value that indicates whether the ISO 8601 Ordinal Date was parsed successfully.</returns>
    public static bool TryParse(string value, [NotNullWhen(true)] out Iso8601OrdinalDate? result)
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
