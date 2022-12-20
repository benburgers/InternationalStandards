/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Exceptions;

/// <summary>
/// An exception that is thrown if an error occurred during the processing of I/O for ISO codes.
/// </summary>
public abstract class IsoIOException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="IsoIOException" />.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">The optional inner exception.</param>
    protected IsoIOException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
