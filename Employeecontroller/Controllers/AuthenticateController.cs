using Entities.Dtos;
using Entities.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employeecontroller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        public AuthenticateController(IAuthenticateService authenticateService)
            {

                _authenticateService = authenticateService;

             }

        [HttpPost]
                [Route("UserSignIn")]
                public async Task<IActionResult> UserSignIn(LoginDto loginDTOObj)
                {
                    var result = await _authenticateService.UserSignIn(loginDTOObj);
                    return Ok(result);
        }
    }
}
