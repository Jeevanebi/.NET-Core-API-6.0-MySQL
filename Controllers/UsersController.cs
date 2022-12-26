using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIService.Data;
using APIService.Models;
using Microsoft.AspNetCore.Authorization;
using APIService.Repository;

namespace APIService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _user;

        public UsersController(IUserService userService)
        {
            _user = userService;
        }

        // GET: api/Users

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetUsers()
        {
            var AllUser =  _user.GetUsers();
            return Ok(AllUser);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Guest")]
        public IActionResult GetUserbyId(int id)
        {
            var userById =  _user.GetUserbyId(id);

            if (userById == null)
            {
                return NotFound();
            }

            return Ok(userById);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Guest")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.Userid)
            {
                return BadRequest();
            }

            try
            {
                _user.PutUser(id, user);
            }


            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        [Authorize(Roles = "Admin, Guest")]
        public IActionResult PostUser([FromBody] User user)
        {
            var createUser = _user.PostUser(user);
            return CreatedAtAction("GetUser", new { id = user.Userid }, createUser);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser(int id)
        {
            var user = _user.GetUserbyId(id); 
            if (user == null)
            {
                return NotFound("User Not Found");
            }

            _user.DeleteUser(user);
            return NotFound("User Deleted");
        }

        private bool UserExists(int id)
        {
            return _user.IsExist(id);
        }
    }
}
