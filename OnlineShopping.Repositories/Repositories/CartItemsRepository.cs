using OnlineShopping.Data;
using OnlineShopping.Data.Models;
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Repositories.Repositories
{
    public class CartItemsRepository : Repository<CartItems>, ICartItemsRepository
    {
        public OnlineShoppingContext OnlineShoppingContext
        {
            get
            {
                return Context as OnlineShoppingContext;
            }
        }

        public CartItemsRepository(OnlineShoppingContext context) : base(context)
        {
        }
    }
}
