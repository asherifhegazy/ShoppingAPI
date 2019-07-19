using OnlineShopping.Data;
using OnlineShopping.Data.Domain.Models;
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopping.Repositories.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public OnlineShoppingContext OnlineShoppingContext
        {
            get
            {
                return Context as OnlineShoppingContext;
            }
        }

        public UserRepository(OnlineShoppingContext context): base(context)
        {
        }

        public User GetUserByUsername(string username)
        {
            var user = OnlineShoppingContext.Users.SingleOrDefault(u => u.Username == username);
            return user;
        }

        public override bool Add(User entity)
        {
            if(entity != null)
            {
                if (!IsUserExists(entity.Username))
                {
                    return base.Add(entity);
                }

                return false;
            }

            return false;
        }

        private bool IsUserExists(string username)
        {
            var result = OnlineShoppingContext.Users.Any(u => u.Username == username);
            return result;
        }

    }
}
