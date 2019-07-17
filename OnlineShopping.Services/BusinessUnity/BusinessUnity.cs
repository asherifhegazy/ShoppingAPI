using OnlineShopping.Services.Interfaces;
using OnlineShopping.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services.BusinessUnity
{
    public class BusinessUnity
    {
        public static IUserService UserService { get; set; }

        public static bool? Initiated { get; set; } = false;

        static BusinessUnity()
        {
            Initiated = Initialize();
        }

        private static bool? Initialize()
        {
            try
            {
                UserService = new UserService();
                return true;
            }
            catch 
            {

                return false;
            }
        }
    }
}
