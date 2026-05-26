using Dapper;
using Entities.Interfaces;
using Entities.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbconnectivity.ConnectionFactory
{
    public class LoggingFactory : ILoggingFactory
    {
        #region connectionFactory
        private readonly IConnectionFactory _connectionFactory;
        public LoggingFactory(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        #endregion


        public async Task<bool> AddLoggingMessages(string userName, string logLevel, string messageTemplate)
        {
            using (IDbConnection con = _connectionFactory.Hotel_dbConnectionstring())
            {
                //DynamicParameters used in dapper,to pass the values to storedprocedure parameters.
                DynamicParameters p = new DynamicParameters();
                p.Add(StoredProcedureparameters.Logging_UserName, userName);
                p.Add(StoredProcedureparameters.Logging_LogLevel, logLevel);
                p.Add(StoredProcedureparameters.Logging_MessageTemplate, messageTemplate);
                await con.ExecuteScalarAsync(Storedprocedurenames.AddLoggingMessages, p, commandType: CommandType.StoredProcedure);
                return true;
            }

        }

        public async Task<bool> AddProjectLevelErrorlogAsync(string statusCode, string ErrorMessage, string StackTraceError, string InnerExceptionError)
        {
            using (IDbConnection con = _connectionFactory.Hotel_dbConnectionstring())
            {
                //DynamicParameters used in dapper,to pass the values to storedprocedure parameters.
                DynamicParameters p = new DynamicParameters();
                p.Add(StoredProcedureparameters.ErrorLog_StatusCode, statusCode);
                p.Add(StoredProcedureparameters.ErrorLog_ErrorMessage, ErrorMessage);
                p.Add(StoredProcedureparameters.ErrorLog_StackTraceError, StackTraceError);
                p.Add(StoredProcedureparameters.ErrorLog_InnerExceptionError, InnerExceptionError);
                await con.ExecuteScalarAsync(Storedprocedurenames.AddProjectLevelErrorlog, p, commandType: CommandType.StoredProcedure);
                return true;
            }

        }
    }
}
