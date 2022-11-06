/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Json.Iso639.Exceptions;

/// <summary>
/// An exception that is thrown if a JSON converter for the ISO 639 standard encounters an error.
/// </summary>
public sealed class Iso639JsonConverterException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639JsonConverterException" />.
    /// </summary>
    /// <param name="message">
    /// The exception message.
    /// </param>
    /// <param name="innerException">
    /// An inner exception.
    /// </param>
    public Iso639JsonConverterException(string message, Exception? innerException)
        : base(message, innerException)
    {
    }
}
