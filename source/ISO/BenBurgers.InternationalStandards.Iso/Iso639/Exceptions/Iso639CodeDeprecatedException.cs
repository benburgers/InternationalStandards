/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639.Exceptions;

/// <summary>
/// An exception that is thrown if an ISO 639 code is deprecated and deprecated codes are not allowed.
/// </summary>
public sealed class Iso639CodeDeprecatedException : Iso639Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639CodeDeprecatedException" />.
    /// </summary>
    internal Iso639CodeDeprecatedException(Iso639Code iso639Code)
        : base(GetExceptionMessage(iso639Code))
    {
    }

    private static string GetExceptionMessage(Iso639Code iso639Code)
    {
        return string.Format(ExceptionMessages.CodeDeprecated, iso639Code);
    }
}
