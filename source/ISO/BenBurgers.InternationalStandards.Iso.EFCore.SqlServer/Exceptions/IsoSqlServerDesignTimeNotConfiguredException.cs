/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU General Public License version 3.
 */

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Exceptions;

/// <summary>
/// An exception that is thrown if the Entity Framework Core SQL Server Design Time services have not been configured.
/// </summary>
public sealed class IsoSqlServerDesignTimeNotConfiguredException : IsoSqlServerException
{
    internal IsoSqlServerDesignTimeNotConfiguredException()
        : base(ExceptionMessages.IsoSqlServerDesignTimeServicesNotConfigured) { }
}
