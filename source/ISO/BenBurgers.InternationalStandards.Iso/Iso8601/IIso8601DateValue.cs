/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

/// <summary>
/// An ISO 8601 Date value.
/// </summary>
public interface IIso8601DateValue : IIso8601Value
{
    /// <summary>
    /// Gets the <see cref="DateOnly" /> representation.
    /// </summary>
    DateOnly ToDate();

    /// <summary>
    /// Gets the <see cref="DateTime" /> representation.
    /// </summary>
    DateTime ToDateTime();

    /// <summary>
    /// Gets the <see cref="DateTimeOffset" /> representation.
    /// </summary>
    DateTimeOffset ToDateTimeOffset();
}
