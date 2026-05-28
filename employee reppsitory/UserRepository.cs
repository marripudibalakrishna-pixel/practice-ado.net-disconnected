using Dapper;
using Dbconnectivity.ConnectionFactory;
using Entities.Dtos;
using Entities.Interfaces;
using Entities.Models;
using Entities.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace employee_reppsitory
{
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<UserSignInResponse> UserResgistration(Users usersObj)
        {
            using(IDbConnection cn = _connectionFactory.Hotel_dbConnectionstring())
            {
                var encryptText = EncryptionLibrary.EncryptText(usersObj.Password);
                //==========******For Testing Point of view you  can see the  decrypt text=======
                var decryptText = EncryptionLibrary.DecryptText(encryptText);
                //===========================================================================
                var p = new DynamicParameters();
                p.Add("@UserName", usersObj.Username);
                p.Add("@Password", encryptText);//here pass the encrypted string to store in database.password is secure
                p.Add("@EmailId", usersObj.Email   );
                p.Add("@PhoneNumber", usersObj.PhoneNumber);
                p.Add("@Address", usersObj.Address);
                p.Add("@IsActive", usersObj.IsActive);
                var result = await cn.QuerySingleAsync<UserSignInResponse>(Storedprocedurenames.Usp_UserResgistration, p, commandType: CommandType.StoredProcedure);
                return result;
            }
             
        }
    }
}