/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso3166;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso3166.Exceptions;

/// <summary>
/// An exception that is thrown if an ISO 3166 Alpha Mode is not supported.
/// </summary>
public sealed class Iso3166AlphaModeNotSupportedException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso3166AlphaModeNotSupportedException" />.
    /// </summary>
    /// <param name="alphaMode">
    /// The alpha mode that is not supported.
    /// </param>
    internal Iso3166AlphaModeNotSupportedException(Iso3166AlphaMode alphaMode)
        : base(GetExceptionMessage(alphaMode))
    {
        this.AlphaMode = alphaMode;
    }

    /// <summary>
    /// Gets the ISO 3166 Alpha Mode that is not supported.
    /// </summary>
    public Iso3166AlphaMode AlphaMode { get; }

    private static string GetExceptionMessage(Iso3166AlphaMode alphaMode)
    {
        return string.Format(ExceptionMessages.AlphaModeNotSupported, alphaMode.ToString());
    }
}
