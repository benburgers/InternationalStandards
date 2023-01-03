/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso3166.Exceptions;

/// <summary>
/// An exception that is thrown if the provided Alpha code for ISO 3166 is invalid.
/// </summary>
public sealed class Iso3166AlphaInvalidException : Iso3166Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166AlphaInvalidException" />.
    /// </summary>
    /// <param name="alpha">
    /// The Alpha code.
    /// </param>
    internal Iso3166AlphaInvalidException(string alpha)
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
