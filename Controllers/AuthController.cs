using APIService.Models;
using APIService.Repository;
using APIService.Service;
using Microsoft.AspNetCore.Mvc;


namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        private readonly IUserService _userservice;

        public AuthController(IAuthService AuthService,IUserService userService)
        {
            _auth = AuthService;
            _userservice = userService;
        }

        // POST api/<AuthController>
        [HttpPost]
        [Route("Authentication")]
        public IActionResult Post([FromBody] Authentication authentication)
        {
            var user = _auth.Authenticate(authentication);

            if (user != null)
            {
                var token = _auth.Generate(user);

                //if(user.Role == "Admin")
                //{
                //    var users = _userservice.GetUserbyId(user.Userid);
                //}
                //else if(user.Role == "Guest")
                //{
                //    var users = _userservice.PostUser(user);
                //}
                
                return Ok(new
                {
                    Id = user.Userid,
                    Username = user.Username,
                    Email = user.Email,
                    Phone = user.PhoneNo,
                    Created_at = DateTime.UtcNow,
                    Token = token
                });
            }

            return NotFound("User Not Found");
        }

    }
}
