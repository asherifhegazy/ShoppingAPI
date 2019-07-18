using OnlineShopping.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsers();

        UserDTO GetUserByID(int id);

        bool AddUser(UserDTO userDTO);

        bool RemoveUser(int id);

        UserDTO GetUserByUsername(string username);
    }
}
