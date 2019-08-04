using OnlineShopping.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetAllOrdersByUserID(int uid);

        Task<bool> AddOrderByUserID(int uid);

        OrderDTO GetOrderByID(int id);

        IEnumerable<OrderItemDTO> GetOrderItems(int oid);
    }
}
