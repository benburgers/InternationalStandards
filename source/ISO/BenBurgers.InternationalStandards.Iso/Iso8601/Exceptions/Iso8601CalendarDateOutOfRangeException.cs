/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.Iso8601.Exceptions;

/// <summary>
/// An exception that is thrown if an <see cref="Iso8601CalendarDate" /> receives a value that is out of the accepted range.
/// </summary>
public sealed class Iso8601CalendarDateOutOfRangeException : Iso8601Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="Iso8601CalendarDateOutOfRangeException" />.
    /// </summary>
    /// <param name="componentName">The name of the component that is out of range.</param>
    internal Iso8601CalendarDateOutOfRangeException(string componentName)
        : base(CreateExceptionMessage(componentName))
    {
        this.ComponentName = componentName;
    }

    /// <summary>
    /// Gets the name of the component that is out of range.
    /// </summary>
    public string ComponentName { get; }

    private static string CreateExceptionMessage(string componentName) =>
        string.Format(ExceptionMessages.CalendarDateOutOfRange, componentName);
}
