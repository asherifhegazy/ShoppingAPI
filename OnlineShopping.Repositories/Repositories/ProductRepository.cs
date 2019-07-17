using OnlineShopping.Data;
using OnlineShopping.Data.Models;
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Repositories.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public OnlineShoppingContext OnlineShoppingContext
        {
            get
            {
                return Context as OnlineShoppingContext;
            }
        }

        public ProductRepository(OnlineShoppingContext context) : base(context)
        {
        }
    }
}
