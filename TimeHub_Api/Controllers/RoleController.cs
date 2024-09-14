using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeHub_BAT.Interfaces;
using TimeHub_Modules.Model;

namespace TimeHub_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;
        public RoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [Route("CreateRole")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(Role role)
        {
            try
            {
                var res = await _userRoleService.CreateUserRole(role);
                if (res != null)
                {
                    return StatusCode(200, res);
                }
                return StatusCode(406, null);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message + " /n " + ex.InnerException.Message);
            }
        }
    }
}
