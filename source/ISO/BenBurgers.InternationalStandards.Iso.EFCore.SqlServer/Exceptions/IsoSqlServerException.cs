/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Exceptions;

/// <summary>
/// An exception that is thrown if an error occurred in Entity Framework Core SQL Server for ISO standards.
/// </summary>
public abstract class IsoSqlServerException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="IsoSqlServerException" />.
    /// </summary>
    /// <param name="message">
    /// The exception message.
    /// </param>
    /// <param name="innerException">
    /// The inner exception.
    /// </param>
    protected IsoSqlServerException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
