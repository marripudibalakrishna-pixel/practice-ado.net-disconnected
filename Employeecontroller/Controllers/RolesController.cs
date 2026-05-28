using Entities.Dtos;
using Entities.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employeecontroller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;
        public RolesController(IRolesService rolesService)

        {
            _rolesService = rolesService;
        }

        [HttpPost]
        [Route("AddRoles")]
        public async Task<IActionResult> AddRoles(RolesDto roles)
        {
            var result = await _rolesService.RolesCreation(roles);
            return Ok(result);
        }
    }
}
