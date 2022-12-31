/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601DateTime
{
    /// <summary>
    /// Returns a string representation of the ISO 8601 Date and Time combination.
    /// </summary>
    /// <returns>The string representation of the ISO 8601 Date and Time combination.</returns>
    public override string ToString() =>
        (this.Date, this.Time) switch
        {
            ({ } date, { } time) => $"{date}{DateTimeSeparator}{time}",
            ({ } date, null) => date.ToString(),
            (null, { } time) => time.ToString(),
            _ => string.Empty
        };
}
