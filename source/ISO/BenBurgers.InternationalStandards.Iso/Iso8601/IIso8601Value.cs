/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

/// <summary>
/// An ISO 8601 value.
/// </summary>
public interface IIso8601Value
{
    /// <summary>
    /// Returns the string representation of the ISO 8601 value.
    /// </summary>
    /// <returns>The string representation of the ISO 8601 value.</returns>
    string ToString();
}
