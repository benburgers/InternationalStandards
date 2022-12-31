/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601;

/// <summary>
/// An ISO 8601 Time Value.
/// </summary>
public interface IIso8601TimeValue : IIso8601Value
{
    /// <summary>
    ///     Converts the ISO 8601 Time value to a <see cref="DateTime" />.
    /// </summary>
    /// <param name="kind">
    ///     The date and time kind.
    ///     <list type="table">
    ///         <item>
    ///             <term><see cref="DateTimeKind.Unspecified" /></term>
    ///             <description>If the time value has an UTC offset, the value is translated to UTC.</description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="DateTimeKind.Utc" /></term>
    ///             <description>If the time value has an UTC offset, the value is translated to UTC.</description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="DateTimeKind.Local" /></term>
    ///             <description>The value is translated to the local UTC offset.</description>
    ///         </item>
    ///     </list>
    /// </param>
    /// <returns>The ISO 8601 Time value as a <see cref="DateTime" />.</returns>
    DateTime ToDateTime(DateTimeKind kind = DateTimeKind.Unspecified);

    /// <summary>
    /// Converts the ISO 8601 Time value to a <see cref="DateTimeOffset" />.
    /// </summary>
    /// <returns>The ISO 8601 Time value as a <see cref="DateTimeOffset" />.</returns>
    DateTimeOffset ToDateTimeOffset();

    /// <summary>
    /// Converts the ISO 8601 Time value to a <see cref="TimeOnly" />.
    /// </summary>
    /// <param name="utcOffset">The UTC offset.</param>
    /// <returns>The time value in the requested UTC offset, or in UTC if <paramref name="utcOffset" /> is <see langword="null" />.</returns>
    TimeOnly ToTime(TimeSpan? utcOffset = null);
}
