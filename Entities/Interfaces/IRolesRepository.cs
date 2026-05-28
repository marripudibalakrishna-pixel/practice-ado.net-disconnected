using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IRolesRepository
    {
        public Task<UserSignInResponse> RolesCreation(Roles rolesobj);
    }
}
