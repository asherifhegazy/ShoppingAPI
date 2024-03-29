﻿using OnlineShopping.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);
    }
}
