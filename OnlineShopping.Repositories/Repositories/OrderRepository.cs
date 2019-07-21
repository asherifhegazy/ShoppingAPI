using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data;
using OnlineShopping.Data.Domain.Models;
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Order GetOrderByID(int id)
        {
            return OnlineShoppingContext.Orders
                .Include(o => o.OrderItems)
                .SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetAllOrdersByUserID(int uid)
        {
            return OnlineShoppingContext.Orders
                .Include(o => o.OrderItems)
                .Where(o => o.UserId == uid);
        }
    }
}
