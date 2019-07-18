using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();

        User GetUserByID(int id);

        bool AddUser(User user);

        bool RemoveUser(int id);

        User GetUserByUsername(string username);
    }
}
