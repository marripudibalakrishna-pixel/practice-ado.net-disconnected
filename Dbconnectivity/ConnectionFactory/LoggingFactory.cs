using Dapper;
using Entities.Interfaces;
using Entities.Utils;
using Microsoft.Extensions.Logging;
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
        private readonly IConnectionFactory _connectionFactory;
        public LoggingFactory(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<bool> IlogMessages(string name, string loglevel, string messagetemplate)
        {
            using (IDbConnection con = _connectionFactory.Hotel_dbConnectionstring())
            {
                DynamicParameters p = new DynamicParameters();
                p.Add(StoredProcedureparameters.username, name);
                p.Add(StoredProcedureparameters.loglevel, loglevel);
                p.Add(StoredProcedureparameters.messagetemplate, messagetemplate);
                await con.ExecuteScalarAsync(Storedprocedurenames.projectlevellogdb, p, commandType: CommandType.StoredProcedure);
                   
                    
                    }
            return true;
        }
    }
}
