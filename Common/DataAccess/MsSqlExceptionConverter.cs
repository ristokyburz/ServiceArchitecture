using System;
using System.Data.SqlClient;
using NHibernate.Exceptions;

namespace Common.DataAccess
{
    public class MsSqlExceptionConverter
    {
        public Exception Convert(AdoExceptionContextInfo exInfo)
        {
            var sqle = ADOExceptionHelper.ExtractDbException(exInfo.SqlException) as SqlException;
            if (sqle != null)
            {
                switch (sqle.Number)
                {
                    case -2: // timeout
                    case -2147217871: // timeout
                    case 11: // network error
                    case 1205: // deadlock
                        return new TransientErrorException("Temporary db error occured. Try again later.", sqle);

                    // case 208: // sql grammar
                    // case 547: // constraint violation
                    // case 3960: // stale object state (does not occur with ReadCommitted isolation level). Should trigger reload on client side
                    default:
                        return new ApplicationException("DB error", sqle);

                }
            }
            return SQLStateConverter.HandledNonSpecificException(exInfo.SqlException,
                exInfo.Message, exInfo.Sql);
        }
    }
}