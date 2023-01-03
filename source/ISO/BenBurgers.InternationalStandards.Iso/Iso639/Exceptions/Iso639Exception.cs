/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639.Exceptions;

/// <summary>
/// An exception that is thrown if an error occurs while processing ISO 639 codes.
/// </summary>
public abstract class Iso639Exception : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639Exception" />.
    /// </summary>
    /// <param name="message">
    /// The exception message.
    /// </param>
    /// <param name="innerException">
    /// The inner exception.
    /// </param>
    protected Iso639Exception(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
