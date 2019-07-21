using OnlineShopping.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetAllOrdersByUserID(int uid);

        bool AddOrderByUserID(int uid,IEnumerable<OrderItemDTO> orderItemsDTO);
        bool AddOrderByUserID(int uid);

        OrderDTO GetOrderByID(int id);

        IEnumerable<OrderItemDTO> GetOrderItems(int oid);
    }
}
