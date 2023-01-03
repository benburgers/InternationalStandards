/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639.Exceptions;

/// <summary>
/// An exception that is thrown if an invalid ISO 639 Alpha code was specified.
/// </summary>
public sealed class Iso639AlphaInvalidException : Iso639Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639AlphaInvalidException" />.
    /// </summary>
    /// <param name="alpha">
    /// The invalid Alpha code.
    /// </param>
    internal Iso639AlphaInvalidException(string alpha)
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
