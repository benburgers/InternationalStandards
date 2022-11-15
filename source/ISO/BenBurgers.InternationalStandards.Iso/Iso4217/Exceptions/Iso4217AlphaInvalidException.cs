/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso4217.Exceptions;

/// <summary>
/// An exception that is thrown if the Alpha-3 three-letter code for an ISO 4217 code is invalid.
/// </summary>
public sealed class Iso4217AlphaInvalidException : Iso4217Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso4217AlphaInvalidException" />.
    /// </summary>
    /// <param name="alpha">
    /// The invalid Alpha-3 code.
    /// </param>
    internal Iso4217AlphaInvalidException(string alpha)
        : base(GetExceptionMessage(alpha))
    {
        this.Alpha = alpha;
    }

    /// <summary>
    /// Gets the invalid Alpha code.
    /// </summary>
    public string Alpha { get; }

    private static string GetExceptionMessage(string alpha)
    {
        return string.Format(ExceptionMessages.AlphaInvalid, alpha);
    }
}
