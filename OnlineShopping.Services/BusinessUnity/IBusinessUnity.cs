using OnlineShopping.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services.BusinessUnity
{
    public interface IBusinessUnity
    {
        IUserService UserService { get; set; }

        IProductService ProductService { get; set; }

        IProductImageService ProductImageService { get; set; }

        ICartItemService CartItemService { get; set; }

        IOrderService OrderService { get; set; }
    }
}
