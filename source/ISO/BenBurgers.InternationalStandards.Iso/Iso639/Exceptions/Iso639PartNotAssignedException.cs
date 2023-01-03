/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso639.Exceptions;

/// <summary>
/// An exception that is thrown if an ISO 639 part is requested where it is not assigned.
/// </summary>
/// <example>
/// An ISO 639 code has an ISO 639-3 designation, but not an ISO 639-1 or ISO 639-2 designation,
/// and one of the latter is requested.
/// </example>
public sealed class Iso639PartNotAssignedException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso639PartNotAssignedException" />.
    /// </summary>
    /// <param name="code">
    /// The <see cref="Iso639Code" /> that does not have a designation for the requested part.
    /// </param>
    /// <param name="part">
    /// The ISO 639-1, ISO 639-2T or ISO 639-2B, or ISO 639-3 part.
    /// </param>
    internal Iso639PartNotAssignedException(Iso639Code code, Iso639Part part)
        : base(GetExceptionMessage(code, part))
    {
        this.Code = code;
        this.Part = part;
    }

    /// <summary>
    /// Gets the <see cref="Iso639Code" /> that does not have a designation for the requested part.
    /// </summary>
    public Iso639Code Code { get; }

    /// <summary>
    /// Gets the ISO 639-1, ISO 639-2T or ISO 639-2B, or ISO 639-3 part that is not assigned.
    /// </summary>
    internal Iso639Part Part { get; }

    private static string GetExceptionMessage(Iso639Code code, Iso639Part part)
    {
        return string.Format(ExceptionMessages.PartNotAssigned, code, part);
    }
}
