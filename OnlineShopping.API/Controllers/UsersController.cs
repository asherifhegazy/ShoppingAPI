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
        private readonly IBusinessUnity _businessUnity;

        public UsersController(IBusinessUnity businessUnity)
        {
            _businessUnity = businessUnity;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            var users = _businessUnity.UserService.GetAllUsers();
            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            var user = _businessUnity.UserService.GetUserByID(id);
            return user;
        }

        // GET: api/Users/5
        [HttpGet("{username}")]
        public User GetUserByUsername(string username)
        {
            var user = _businessUnity.UserService.GetUserByUsername(username);
            return user;
        }

        // POST: api/Users
        [HttpPost]
        public bool AddUser([FromBody] User user)
        {
            var isAdded = _businessUnity.UserService.AddUser(user);
            return isAdded;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool RemoveUser(int id)
        {
            var isDeleted = _businessUnity.UserService.RemoveUser(id);
            return isDeleted;
        }
    }
}
