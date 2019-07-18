using OnlineShopping.Data;
using OnlineShopping.Data.Domain.Models;
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Repositories.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OnlineShoppingContext OnlineShoppingContext
        {
            get
            {
                return Context as OnlineShoppingContext;
            }
        }

        public OrderRepository(OnlineShoppingContext context) : base(context)
        {
        }
    }
}
