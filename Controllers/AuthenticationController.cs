using Microsoft.AspNetCore.Mvc;
using ProiectPractica_ASE.Models;
using ProiectPractica_ASE.Services;

namespace ProiectPractica_ASE.Controllers
{
    [Route("controller")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public IUserService _userService;
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        public IActionResult Authenticate(AuthenticateRequest request)
        {
            var response=_userService.Authenticate(request);
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(response);
        }
        
    }
}
