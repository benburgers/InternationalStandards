/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using System.Text;

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601Time
{
    /// <summary>
    /// Returns a string representation of the ISO 8601 Time.
    /// </summary>
    /// <returns>The string representation of the ISO 8601 Time.</returns>
    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.Append(this.Hour.ToString("D2"));
        if (this.Minute is { } minute)
        {
            if (!this.Simple)
                builder.Append(':');
            builder.Append(minute.ToString("D2"));
        }
        if (this.Second is { } second)
        {
            if (!this.Simple)
                builder.Append(':');
            builder.Append(second.ToString("D2"));
            if (this.Fraction is { } fraction)
            {
                builder.Append(',');
                var fractionString =
                    fraction == 0.0m
                    ? "0"
                    : fraction.ToString()["0.".Length..];
                builder.Append(fractionString);
            }
        }
        if (this.UtcOffset is { } utcOffset)
        {
            if (utcOffset == TimeSpan.Zero)
                builder.Append('Z');
            else
            {
                var sign = utcOffset > TimeSpan.Zero ? '+' : '-';
                builder.Append(sign);
                if (this.Simple)
                    builder.Append(utcOffset.ToString("hhmm"));
                else
                    builder.Append(utcOffset.ToString(@"hh\:mm"));
            }
        }
        return builder.ToString();
    }
}
