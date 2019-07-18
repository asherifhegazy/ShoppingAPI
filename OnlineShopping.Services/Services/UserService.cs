using OnlineShopping.Data.Models;
using OnlineShopping.Repositories.UnitOfWork;
using OnlineShopping.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopping.Services.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddUser(User user)
        {
            if (user != null)
            {

                var result = _unitOfWork.UserRepository.Add(user);
                _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var result = _unitOfWork.UserRepository.GetAll();
            return result;
        }

        public User GetUserByID(int id)
        {
            var result = _unitOfWork.UserRepository.GetByID(id);
            return result;
        }

        public User GetUserByUsername(string username)
        {
            var result = _unitOfWork.UserRepository.GetUserByUsername(username);
            return result;
        }

        public bool RemoveUser(int id)
        {
            var user = GetUserByID(id);
            if (user != null)
            {
                var result = _unitOfWork.UserRepository.Remove(user);
                _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }
    }
}
