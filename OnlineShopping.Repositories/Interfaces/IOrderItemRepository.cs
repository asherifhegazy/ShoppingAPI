﻿using OnlineShopping.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Repositories.Interfaces
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        bool AddOrderItems(IEnumerable<OrderItem> orderItems);

        IEnumerable<OrderItem> GetOrderItems(int oid);
    }
}
