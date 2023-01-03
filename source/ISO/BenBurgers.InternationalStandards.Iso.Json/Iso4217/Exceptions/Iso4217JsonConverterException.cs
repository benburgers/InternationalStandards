/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Json.Iso4217.Exceptions;

/// <summary>
/// An exception that is thrown if a JSON Converter for the ISO 4217 standard encounters an error.
/// </summary>
public sealed class Iso4217JsonConverterException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217JsonConverterException" />.
    /// </summary>
    /// <param name="message">
    /// The exception message.
    /// </param>
    /// <param name="innerException">
    /// An inner exception.
    /// </param>
    internal Iso4217JsonConverterException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
