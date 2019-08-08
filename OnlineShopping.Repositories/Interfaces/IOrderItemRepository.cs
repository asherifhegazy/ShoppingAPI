using OnlineShopping.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Repositories.Interfaces
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task<bool> AddOrderItems(IEnumerable<OrderItem> orderItems);

        IEnumerable<OrderItem> GetOrderItems(int oid);
    }
}
