using employee_reppsitory;
using Entities.Dtos;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_service
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IAuthenticateRepository _authenticateRepository;
        public AuthenticateService(IAuthenticateRepository authenticateRepository) 
        {
            _authenticateRepository = authenticateRepository;
        }
        public Task<UserRolesInformationResponse> GetUserRolesInformation(LoginDto loginDTOObj)
        {
            throw new NotImplementedException();
        }

        public async Task<UserSignInResponse> UserSignIn(LoginDto loginDTOObj)
        {
            var res= await _authenticateRepository.UserSignIn(loginDTOObj);
            return res;
        }
    }
}
