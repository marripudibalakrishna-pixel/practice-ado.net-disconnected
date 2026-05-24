using Entities.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbconnectivity.ConnectionFactory
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection Hotel_dbConnectionstring()
        {
           //using SqlConnection sqlConnection = new SqlConnection(Convert.ToString(_configuration.GetSection("ConnectionStrings:HotelDb").Value));
             var sqlConnection = Convert.ToString(_configuration.GetSection("ConnectionStrings:HotelmanagementsqlConnectionString").Value);
            SqlConnection con = new SqlConnection(sqlConnection);
            return  con;
        }
    }
}
