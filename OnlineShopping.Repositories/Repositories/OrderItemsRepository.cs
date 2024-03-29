﻿using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data;
using OnlineShopping.Data.Domain.Models;
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Repositories.Repositories
{
    public class OrderItemsRepository : Repository<OrderItem>, IOrderItemRepository
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

        public async Task<bool> AddOrderItems(IEnumerable<OrderItem> orderItems)
        {
            if(orderItems != null)
            {
                await OnlineShoppingContext.AddRangeAsync(orderItems);

                return true;
            }

            return false;
        }

        public IEnumerable<OrderItem> GetOrderItems(int oid)
        {
            return OnlineShoppingContext.OrderItems
                .Include(oi=>oi.Product)
                .Where(oi => oi.OrderId == oid);
        }
    }
}
