using OnlineShopping.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services.BusinessUnity
{
    public interface IBusinessUnity
    {
        IUserService UserService { get; set; }
    }
}
