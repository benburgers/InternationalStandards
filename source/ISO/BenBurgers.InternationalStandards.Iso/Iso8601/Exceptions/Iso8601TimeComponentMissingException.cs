/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601.Exceptions;

/// <summary>
/// An exception that is thrown if an ISO 8601 value does not have a time component.
/// </summary>
public sealed class Iso8601TimeComponentMissingException : Iso8601Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601TimeComponentMissingException" />.
    /// </summary>
    internal Iso8601TimeComponentMissingException()
        : base(ExceptionMessages.TimeComponentMissing)
    {
    }
}
