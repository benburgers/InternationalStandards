/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso3166.Exceptions;

/// <summary>
/// An exception that is thrown if an error has occurred during the processing of an ISO 3166 code.
/// </summary>
public abstract class Iso3166Exception : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166Exception" />.
    /// </summary>
    /// <param name="message">
    /// The exception message.
    /// </param>
    /// <param name="innerException">
    /// The optional inner exception.
    /// </param>
    protected Iso3166Exception(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
