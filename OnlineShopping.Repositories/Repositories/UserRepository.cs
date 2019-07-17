using OnlineShopping.Data;
using OnlineShopping.Data.Models;
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
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
    }
}
