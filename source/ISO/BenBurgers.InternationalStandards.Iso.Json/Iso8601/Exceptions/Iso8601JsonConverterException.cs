/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Json.Iso8601.Exceptions;

/// <summary>
/// An exception that is thrown if a JSON Converter for an ISO 8601 value encounters an error.
/// </summary>
public sealed class Iso8601JsonConverterException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601JsonConverterException" />.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">An optional inner exception.</param>
    internal Iso8601JsonConverterException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
