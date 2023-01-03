/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

public readonly partial struct Iso8601OrdinalDate
{
    /// <summary>
    /// Returns a string representation of this ISO 8601 Ordinal Date.
    /// </summary>
    /// <returns>The string representation of this ISO 8601 Ordinal Date.</returns>
    public override string ToString() =>
        this.Simple
            ? $"{this.Year:D4}{this.DayOfYear:D3}"
            : $"{this.Year:D4}-{this.DayOfYear:D3}";
}
