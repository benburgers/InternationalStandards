/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.IO.Exceptions;

/// <summary>
/// An exception that is thrown if an error occurred during the processing of Input/Output for ISO 639 codes.
/// </summary>
public class Iso639IOException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639IOException" />.
    /// </summary>
    /// <param name="message">
    /// The exception message.
    /// </param>
    /// <param name="innerException">
    /// The inner exception.
    /// </param>
    internal Iso639IOException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
