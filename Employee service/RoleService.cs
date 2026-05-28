using Entities.Dtos;
using Entities.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_service
{
    public class RoleService : IRolesService
    {
        private readonly IRolesRepository _rolesRepository;
        public RoleService(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }
        public async Task<UserSignInResponse> RolesCreation(RolesDto rolesobj)
        {
                Roles roles = new Roles();
                roles.Rolename = rolesobj.Rolename;
                roles.isActive = rolesobj.isActive;
           var result= await _rolesRepository.RolesCreation(roles);
            return result;



        }
    }
}
