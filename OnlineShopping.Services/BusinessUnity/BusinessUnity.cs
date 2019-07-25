using OnlineShopping.Services.Interfaces;
using OnlineShopping.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services.BusinessUnity
{
    public class BusinessUnity: IBusinessUnity
    {
        public IUserService UserService { get; set; }
        public IProductService ProductService { get; set; }
        public IProductImageService ProductImageService { get; set; }
        public ICartItemService CartItemService { get; set; }
        public IOrderService OrderService { get; set; }


        public BusinessUnity(IUserService userService, IProductService productService, IProductImageService productImageService
            , ICartItemService cartItemService, IOrderService orderService)
        {
            UserService = userService;
            ProductService = productService;
            ProductImageService = productImageService;
            CartItemService = cartItemService;
            OrderService = orderService;
        }
    }
}
