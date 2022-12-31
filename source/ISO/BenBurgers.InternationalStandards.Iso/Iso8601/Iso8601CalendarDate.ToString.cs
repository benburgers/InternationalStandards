/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using System.Text;

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601CalendarDate
{
    /// <summary>
    /// Returns the string representation of the ISO 8601 Calendar Date.
    /// </summary>
    /// <returns>The string representation of the ISO 8601 Calendar Date.</returns>
    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.Append(this.Year.ToString("D4"));
        if (this.Month is not { } month)
            return builder.ToString();
        if (!this.Simple)
            builder.Append('-');
        builder.Append(month.ToString("D2"));
        if (this.Day is not { } day)
            return builder.ToString();
        if (!this.Simple)
            builder.Append('-');
        builder.Append(day.ToString("D2"));
        return builder.ToString();
    }
}
