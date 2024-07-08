using Microsoft.AspNetCore.Mvc;
using ShopServer.Business.Request.AddRequest;
using ShopServer.Business.Service;
using ShopServer.Business.Service.Interface;
using System;
using System.Threading.Tasks;

namespace ShopServer.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController: Controller
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody] UserLoginRequest _request)
        {
            try
            {
                var data = await _userService.Login(_request);
                if (data == null)
                    return NotFound();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("siginup")]
        public async Task<IActionResult> siginup([FromBody] UserSignupRequest _request)
        {
            try
            {
                var data = await _userService.Sigin(_request);
                if (data == null)
                    return NotFound();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
