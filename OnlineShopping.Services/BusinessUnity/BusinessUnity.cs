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
        public IProductImagesService ProductImagesService { get; set; }
        public ICartItemsService CartItemsService { get; set; }

        public BusinessUnity(IUserService userService, IProductService productService, IProductImagesService productImagesService
            , ICartItemsService cartItemsService)
        {
            UserService = userService;
            ProductService = productService;
            ProductImagesService = productImagesService;
            CartItemsService = cartItemsService;
        }
    }
}
