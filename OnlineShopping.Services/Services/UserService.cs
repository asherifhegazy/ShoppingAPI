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
        public bool AddUser(User user)
        {
            if(user != null)
            {
                using(var UnitOfWork = new UnitOfWork())
                {
                    var result = UnitOfWork.UserRepository.Add(user);
                    UnitOfWork.SaveChanges();

                    return result;
                }
            }

            return false;
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var UnitOfWork = new UnitOfWork())
            {
                var result = UnitOfWork.UserRepository.GetAll().ToList();
                return result;
            }
        }

        public User GetUserByID(int id)
        {
            using (var UnitOfWork = new UnitOfWork())
            {
                var result = UnitOfWork.UserRepository.GetByID(id);
                return result;
            }
        }

        public User GetUserByUsername(string username)
        {
            using (var UnitOfWork = new UnitOfWork())
            {
                var result = UnitOfWork.UserRepository.GetUserByUsername(username);
                return result;
            }
        }

        public bool RemoveUser(int id)
        {
            var user = GetUserByID(id);
            if(user != null)
            {
                using (var UnitOfWork = new UnitOfWork())
                {
                    var result = UnitOfWork.UserRepository.Remove(user);
                    UnitOfWork.SaveChanges();

                    return result;
                }
            }

            return false;
        }
    }
}
