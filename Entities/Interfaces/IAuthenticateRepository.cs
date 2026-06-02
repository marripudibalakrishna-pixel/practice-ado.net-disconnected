using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IAuthenticateRepository
    {
        Task<UserSignInResponse> UserSignIn(LoginDto loginDTOObj);
        Task<UserRolesInformationResponse> GetUserRolesInformation(LoginDto loginDTOObj);
    }
}
