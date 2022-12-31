/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso8601.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601Time
{
    private enum State
    {
        Hour,
        Minute,
        Second,
        Fraction,
        UtcOffsetHour,
        UtcOffsetMinute
    }

    private const char FractionSymbol = ',';
    private const char Separator = ':';
    private const char TimeZoneUtc = 'Z';
    private const char TimeZoneMinus = '-';
    private const char TimeZonePlus = '+';

    private static decimal? ParseFraction(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return null;
        return decimal.Parse(value);
    }

    private static byte? ParseSixty(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return null;
        return byte.Parse(value);
    }

    private static sbyte? ParseSixtySigned(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return null;
        return sbyte.Parse(value);
    }

    private static sbyte? ParseUtcOffset(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return null;
        if (value == "Z") return 0;
        return sbyte.Parse(value);
    }

    private static Iso8601Time ParseCreateResult(
        string hourValue,
        string minuteValue,
        string secondValue,
        string fractionValue,
        string utcOffsetHourValue,
        string utcOffsetMinuteValue,
        bool simple)
    {
        var hour = byte.Parse(hourValue);
        var minuteResult = ParseSixty(minuteValue);
        var secondResult = ParseSixty(secondValue);
        var fractionResult = ParseFraction(fractionValue);
        var utcOffsetHourResult = ParseUtcOffset(utcOffsetHourValue);
        var utcOffsetMinuteResult = ParseSixtySigned(utcOffsetMinuteValue);
        {
            if (utcOffsetHourResult is not null && utcOffsetMinuteResult is null)
                utcOffsetMinuteResult = 0; // hour only
            if (utcOffsetHourResult is { } utcOffsetHour && utcOffsetHour < 0 && utcOffsetMinuteResult is { } utcOffsetMinute)
                utcOffsetMinuteResult = (sbyte)-utcOffsetMinute;
        }

        return (hour, minuteResult, secondResult, fractionResult, utcOffsetHourResult, utcOffsetMinuteResult) switch
        {
            ({ }, { } minute, { } second, { } fraction, { } utcOffsetHour, { } utcOffsetMinute) =>
                new(hour, minute, second, fraction, new TimeSpan(utcOffsetHour, utcOffsetMinute, 0), simple),
            ({ }, { } minute, { } second, { } fraction, null, null) =>
                new(hour, minute, second, fraction, simple),
            ({ }, { } minute, { } second, null, { } utcOffsetHour, { } utcOffsetMinute) =>
                new(hour, minute, second, new TimeSpan(utcOffsetHour, utcOffsetMinute, 0), simple),
            ({ }, { } minute, { } second, null, null, null) =>
                new(hour, minute, second, simple),
            ({ }, { } minute, null, null, { } utcOffsetHour, { } utcOffsetMinute) =>
                new(hour, minute, new TimeSpan(utcOffsetHour, utcOffsetMinute, 0), simple),
            ({ }, { } minute, null, null, null, null) =>
                new(hour, minute, simple),
            ({ }, null, null, null, { } utcOffsetHour, { } utcOffsetMinute) =>
                new(hour, new TimeSpan(utcOffsetHour, utcOffsetMinute, 0), simple),
            ({ }, null, null, null, null, null) =>
                new(hour, simple),
            _ => new Iso8601Time()
        };
    }

    /// <summary>
    /// Parses an ISO 8601 Time from <paramref name="value" />.
    /// </summary>
    /// <param name="value">The string value that contains a representation of an ISO 8601 Time.</param>
    /// <returns>The ISO 8601 Time from <paramref name="value" />.</returns>
    /// <exception cref="Iso8601ParseException">
    /// An <see cref="Iso8601ParseException" /> is thrown if <paramref name="value" /> contains a syntax error.
    /// </exception>
    public static Iso8601Time Parse(string value)
    {
        var state = State.Hour;
        var simple = false;
        var hourBuilder = new StringBuilder();
        var minuteBuilder = new StringBuilder();
        var secondBuilder = new StringBuilder();
        var fractionBuilder = new StringBuilder();
        var utcOffsetHourBuilder = new StringBuilder();
        var utcOffsetMinuteBuilder = new StringBuilder();

        for (var i = 0; i < value.Length; i++)
        {
            switch (value[i], state, simple)
            {
                // Errors
                case ({ } c, _, _) when hourBuilder.Length == 0 && new[] { TimeZoneMinus, TimeZonePlus, TimeZoneUtc }.Contains(c):
                    throw new Iso8601ParseException(i, "ISO 8601 Time must have at least an hour component before a time zone is specified.");
                case ({ } c, _, true) when c == Separator && minuteBuilder.Length > 0:
                    throw new Iso8601ParseException(i, $"Inconsistent simplicity. '{Separator}' is not allowed in simple format.");

                // Separator
                case ({ } c, _, false) when c == Separator:
                    state++;
                    break;

                // Time Zone
                case ({ } c, _, _) when c == TimeZoneMinus || c == TimeZonePlus:
                    state = State.UtcOffsetHour;
                    utcOffsetHourBuilder.Append(c);
                    break;
                case ({ } c, _, _) when c == TimeZoneUtc && hourBuilder.Length > 0 && i == value.Length - 1:
                    utcOffsetHourBuilder.Append(c);
                    return ParseCreateResult(
                        hourBuilder.ToString(),
                        minuteBuilder.ToString(),
                        secondBuilder.ToString(),
                        fractionBuilder.ToString(),
                        utcOffsetHourBuilder.ToString(),
                        utcOffsetMinuteBuilder.ToString(),
                        simple);
                case ({ } c, State.UtcOffsetHour, _) when char.IsDigit(c) && utcOffsetHourBuilder.Length < 3:
                    utcOffsetHourBuilder.Append(c);
                    break;
                case ({ } c, State.UtcOffsetHour, _) when char.IsDigit(c) && utcOffsetHourBuilder.Length == 3:
                    simple = true;
                    state = State.UtcOffsetMinute;
                    utcOffsetMinuteBuilder.Append(c);
                    break;
                case ({ } c, State.UtcOffsetMinute, _) when char.IsDigit(c) && utcOffsetMinuteBuilder.Length < 2:
                    utcOffsetMinuteBuilder.Append(c);
                    break;

                // Hour
                case ({ } c, State.Hour, _) when char.IsDigit(c) && hourBuilder.Length < 2:
                    hourBuilder.Append(c);
                    break;
                case ({ } c, State.Hour, _) when char.IsDigit(c) && hourBuilder.Length == 2:
                    simple = true;
                    state = State.Minute;
                    minuteBuilder.Append(c);
                    break;

                // Minute
                case ({ } c, State.Minute, _) when char.IsDigit(c) && minuteBuilder.Length < 2:
                    minuteBuilder.Append(c);
                    break;
                case ({ } c, State.Minute, true) when char.IsDigit(c) && minuteBuilder.Length == 2:
                    state = State.Second;
                    secondBuilder.Append(c);
                    break;

                // Second
                case ({ } c, State.Second, _) when char.IsDigit(c) && secondBuilder.Length < 2:
                    secondBuilder.Append(c);
                    break;
                case ({ } c, State.Second, _) when c == FractionSymbol && secondBuilder.Length > 0:
                    state = State.Fraction;
                    fractionBuilder.Append("0.");
                    break;

                // Fraction
                case ({ } c, State.Fraction, _) when char.IsDigit(c):
                    fractionBuilder.Append(c);
                    break;

                default:
                    throw new Iso8601ParseException(i, "Unexpected token.");
            }
        }

        return ParseCreateResult(
            hourBuilder.ToString(),
            minuteBuilder.ToString(),
            secondBuilder.ToString(),
            fractionBuilder.ToString(),
            utcOffsetHourBuilder.ToString(),
            utcOffsetMinuteBuilder.ToString(),
            simple);
    }

    /// <summary>
    /// Attempts to parse an <see cref="Iso8601Time" /> from <paramref name="value" />.
    /// </summary>
    /// <param name="value">The string value that contains a representation of an ISO 8601 Time.</param>
    /// <param name="result">The ISO 8601 Time.</param>
    /// <returns>A value that indicates whether the ISO 8601 Time was parsed successfully.</returns>
    public static bool TryParse(string value, [NotNullWhen(true)] out Iso8601Time? result)
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
