using Dapper;
using Entities.Dtos;
using Entities.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee_reppsitory
{
    public class Roles_Repository : IRolesRepository
    {
        public readonly IConnectionFactory _connectionFactory;
        public Roles_Repository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<UserSignInResponse> RolesCreation(Roles rolesobj)
        {
            using (IDbConnection cn =  _connectionFactory.Hotel_dbConnectionstring())
            {
                cn.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Rolename", rolesobj.Rolename);
                parameters.Add("@isActive", rolesobj.isActive);
                var result = await cn.QuerySingleAsync<UserSignInResponse>("Usp_RolesResgistration", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
