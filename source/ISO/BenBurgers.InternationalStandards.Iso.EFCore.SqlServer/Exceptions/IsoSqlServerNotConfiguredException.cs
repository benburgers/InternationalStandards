using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenBurgers.InternationalStandards.Iso.EFCore.SqlServer.Exceptions;

/// <summary>
/// An exception that is thrown if the 
/// </summary>
public sealed class IsoSqlServerNotConfiguredException : IsoSqlServerException
{
    internal IsoSqlServerNotConfiguredException()
        : base(ExceptionMessages.IsoSqlServerNotConfigured)
    {
    }
}
