/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601.Exceptions;

/// <summary>
/// An exception that is thrown if an error occurs during the processing of the ISO 8601 standard.
/// </summary>
public abstract class Iso8601Exception : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601Exception" />.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">An optional inner exception.</param>
    protected Iso8601Exception(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
