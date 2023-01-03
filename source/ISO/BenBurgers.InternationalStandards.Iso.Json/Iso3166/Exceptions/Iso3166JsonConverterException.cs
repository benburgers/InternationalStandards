/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Json.Iso3166.Exceptions;

/// <summary>
/// An exception that is thrown if a JSON converter for the ISO 3166 standard encounters an error.
/// </summary>
public class Iso3166JsonConverterException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166JsonConverterException" />.
    /// </summary>
    /// <param name="message">
    /// The exception message.
    /// </param>
    /// <param name="innerException">
    /// An inner exception.
    /// </param>
    public Iso3166JsonConverterException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
