/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601.Exceptions;

/// <summary>
/// An exception that is thrown if the value of an ISO 8601 Ordinal Date is out of the accepted range.
/// </summary>
public sealed class Iso8601OrdinalDateOutOfRangeException : Iso8601Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601OrdinalDateOutOfRangeException" />.
    /// </summary>
    internal Iso8601OrdinalDateOutOfRangeException()
        : base(ExceptionMessages.OrdinalDateOutOfRange)
    {
    }
}
