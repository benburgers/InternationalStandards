/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso4217.Exceptions;

/// <summary>
/// An exception that is thrown if an error occurs during the processing of an ISO 4217 code.
/// </summary>
public class Iso4217Exception : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217Exception" />.
    /// </summary>
    /// <param name="message">
    /// The exception message.
    /// </param>
    /// <param name="innerException">
    /// The inner exception.
    /// </param>
    internal Iso4217Exception(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
