using OnlineShopping.Mapper;
using OnlineShopping.Mapper.Models;
using OnlineShopping.Repositories.UnitOfWork;
using OnlineShopping.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Services.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddUser(UserDTO userDTO)
        {
            if (userDTO != null)
            {
                var user = SMapper.Map(userDTO);
                var result = await _unitOfWork.UserRepository.Add(user);
                await _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var result = _unitOfWork.UserRepository.GetAll();
            var usersDTO = SMapper.Map(result.ToList());
            
            return usersDTO;
        }

        public UserDTO GetUserByID(int id)
        {
            var result = _unitOfWork.UserRepository.GetByID(id);
            var userDTO = SMapper.Map(result);

            return userDTO;
        }

        public UserDTO GetUserByUsername(string username)
        {
            var result = _unitOfWork.UserRepository.GetUserByUsername(username);
            var userDTO = SMapper.Map(result);

            return userDTO;
        }

        public async Task<bool> RemoveUser(int id)
        {
            var userDTO = GetUserByID(id);
            var user = SMapper.Map(userDTO);

            if (user != null)
            {
                var result = _unitOfWork.UserRepository.Remove(user);
                await _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }
    }
}
