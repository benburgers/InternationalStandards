/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Exceptions;

/// <summary>
/// An exception that is thrown if the Database Context Options Extension for ISO standards has not been configured.
/// </summary>
public class IsoDbContextOptionsExtensionNotConfiguredException : IsoSqlServerException
{
    /// <summary>
    /// Initializes a new instance of <see cref="IsoDbContextOptionsExtensionNotConfiguredException" />.
    /// </summary>
    internal IsoDbContextOptionsExtensionNotConfiguredException()
        : base(ExceptionMessages.IsoSqlServerDbContextOptionsExtensionNotConfigured)
    {
    }
}
