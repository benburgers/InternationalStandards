/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

using BenBurgers.InternationalStandards.Iso.Iso639;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Iso639.Exceptions;

/// <summary>
/// An exception that is thrown if an ISO 639 Part is not supported.
/// </summary>
public sealed class Iso639PartNotSupportedException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639PartNotSupportedException" />.
    /// </summary>
    /// <param name="part">
    /// The ISO 639 Part that is not supported.
    /// </param>
    internal Iso639PartNotSupportedException(Iso639Part part)
        : base(GetExceptionMessage(part))
    {
        this.Part = part;
    }

    /// <summary>
    /// Gets the ISO 639 Part that is not supported.
    /// </summary>
    public Iso639Part Part { get; }

    private static string GetExceptionMessage(Iso639Part part)
    {
        return string.Format(ExceptionMessages.PartNotSupported, part);
    }
}
