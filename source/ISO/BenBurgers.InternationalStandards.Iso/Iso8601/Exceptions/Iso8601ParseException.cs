/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601.Exceptions;

/// <summary>
/// An exception that is thrown if an ISO 8601 value's string representation has a syntax error.
/// </summary>
public sealed class Iso8601ParseException : Iso8601Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601ParseException" />.
    /// </summary>
    /// <param name="index">The index at which the parsing failed.</param>
    /// <param name="reason">The reason the parsing failed.</param>
    internal Iso8601ParseException(int index, string reason)
        : base(CreateExceptionMessage(index, reason))
    {
        this.Index = index;
        this.Reason = reason;
    }

    /// <summary>
    /// Gets the index at which the parsing failed.
    /// </summary>
    public int Index { get; }

    /// <summary>
    /// Gets the reason the parsing failed.
    /// </summary>
    public string Reason { get; }

    private static string CreateExceptionMessage(int index, string reason) =>
        string.Format(ExceptionMessages.Parse, index, reason);
}