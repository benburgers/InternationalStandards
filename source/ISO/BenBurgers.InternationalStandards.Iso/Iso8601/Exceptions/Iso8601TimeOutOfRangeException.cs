/*
 * © 2022 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601.Exceptions;

/// <summary>
/// An exception that is thrown if a value of an ISO 8601 Time is out of range.
/// </summary>
public sealed class Iso8601TimeOutOfRangeException : Iso8601Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601TimeOutOfRangeException" />.
    /// </summary>
    /// <param name="componentName">The name of the component that is out of range.</param>
    internal Iso8601TimeOutOfRangeException(string componentName)
        : base(CreateExceptionMessage(componentName))
    {
        this.ComponentName = componentName;
    }

    /// <summary>
    /// Gets the name of the component that is out of range.
    /// </summary>
    public string ComponentName { get; }

    private static string CreateExceptionMessage(string componentName) =>
        string.Format(ExceptionMessages.TimeOutOfRange, componentName);
}
