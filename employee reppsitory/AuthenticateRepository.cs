using Dapper;
using Dbconnectivity.ConnectionFactory;
using Entities.Dtos;
using Entities.Interfaces;
using Entities.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee_reppsitory
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly IConnectionFactory _connectionFactory; 
        public AuthenticateRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public Task<UserRolesInformationResponse> GetUserRolesInformation(LoginDto loginDTOObj)
        {
            throw new NotImplementedException();
        }

        public async Task<UserSignInResponse> UserSignIn(LoginDto loginDTOObj)
        {
            using(IDbConnection cn = _connectionFactory.Hotel_dbConnectionstring())
            {
                var encryptText = EncryptionLibrary.EncryptText(loginDTOObj.Password);

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserName", loginDTOObj.UserName);
                parameters.Add("Password", encryptText);
               var result= await cn.QueryAsync<UserSignInResponse>("Usp_LoginCheck", parameters, commandType: CommandType.StoredProcedure);
                var status = result.FirstOrDefault();
                return status;
            }
        }
    }
}
