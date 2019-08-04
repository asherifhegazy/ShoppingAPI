using OnlineShopping.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsers();

        UserDTO GetUserByID(int id);

        Task<bool> AddUser(UserDTO userDTO);

        Task<bool> RemoveUser(int id);

        UserDTO GetUserByUsername(string username);
    }
}
