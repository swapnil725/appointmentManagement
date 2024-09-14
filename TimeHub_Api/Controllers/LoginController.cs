using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Threading.Tasks;
using TimeHub_BAT.Interfaces;
using TimeHub_DAT.DBContext;
using TimeHub_Modules.Model;

namespace TimeHub_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("RegisterUser")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            try
            {
                var res = await _userService.CreateUser(user);
                if (res != null)
                {
                    return StatusCode(200, res);
                }
                return StatusCode(406, "EmailId Already Used");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message + " /n " + ex.InnerException.Message);
            }
        }

        [Route("GetUserByEmail")]
        [HttpGet]
        public async Task<IActionResult> GetUserByEmailId(string emailId)
        {
            try
            {
                var res = await _userService.GetUserById(emailId);
                if (res != null)
                {
                    return StatusCode(200, res);
                }
                return StatusCode(404, null);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message + " /n " + ex.InnerException.Message);
            }
        }

        [Route("GetAllUser")]
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var res = await _userService.GetAllUsers();
                if (res?.Count() > 0)
                {
                    return StatusCode(200, res);
                }
                return StatusCode(404, null);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message + " /n " + ex.InnerException.Message);
            }
        }

        [Route("DeleteUserById")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserByEmailId(string id)
        {
            try
            {
                var res = await _userService.DeleteUserById(id);
                if (res)
                {
                    return StatusCode(200, res);
                }
                return StatusCode(404, null);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message + " /n " + ex.InnerException.Message);
            }
        }
    }
}
