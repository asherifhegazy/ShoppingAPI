using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Data.Models;
using OnlineShopping.Services.BusinessUnity;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            var users = BusinessUnity.UserService.GetAllUsers();
            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            var user = BusinessUnity.UserService.GetUserByID(id);
            return user;
        }

        // POST: api/Users
        [HttpPost]
        public bool AddUser([FromBody] User user)
        {
            var isAdded = BusinessUnity.UserService.AddUser(user);
            return isAdded;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool RemoveUser(int id)
        {
            var isDeleted = BusinessUnity.UserService.RemoveUser(id);
            return isDeleted;
        }
    }
}
