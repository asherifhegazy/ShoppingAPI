using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Mapper.Models;
using OnlineShopping.Services.Interfaces;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();

            if (users == null)
                return NotFound();

            return new JsonResult(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUserByID(id);

            if (user == null)
                return NotFound();

            return new JsonResult(user);
        }

        // GET: api/Users/user/ahmed
        [HttpGet("user/{username}")]
        public IActionResult GetUserByUsername(string username)
        {
            var user = _userService.GetUserByUsername(username);

            if (user == null)
                return NotFound();

            return new JsonResult(user);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDTO user)
        {
            var isAdded = await _userService.AddUser(user);
            
            if (!isAdded)
                return NotFound();

            return new JsonResult(isAdded);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            var isDeleted = await _userService.RemoveUser(id);

            if (!isDeleted)
                return NotFound();

            return new JsonResult(isDeleted);
        }
    }
}
