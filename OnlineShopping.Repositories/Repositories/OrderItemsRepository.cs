using OnlineShopping.Data;
using OnlineShopping.Data.Models;
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Repositories.Repositories
{
    public class OrderItemsRepository : Repository<OrderItems>, IOrderItemsRepository
    {
        public OnlineShoppingContext OnlineShoppingContext
        {
            get
            {
                return Context as OnlineShoppingContext;
            }
        }

        public OrderItemsRepository(OnlineShoppingContext context) : base(context)
        {
        }
    }
}
