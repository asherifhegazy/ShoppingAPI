using OnlineShopping.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetOrderByID(int id);

        IEnumerable<Order> GetAllOrdersByUserID(int uid);
    }
}
