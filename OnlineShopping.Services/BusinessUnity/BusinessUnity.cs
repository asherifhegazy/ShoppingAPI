﻿using OnlineShopping.Services.Interfaces;
using OnlineShopping.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services.BusinessUnity
{
    public class BusinessUnity: IBusinessUnity
    {
        public IUserService UserService { get; set; }

        public BusinessUnity(IUserService userService)
        {
            UserService = userService;
        }
    }
}
