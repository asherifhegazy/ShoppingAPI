﻿using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; set; }

        IOrderRepository OrderRepository { get; set; }

        IProductRepository ProductRepository { get; set; }

        IProductImageRepository ProductImageRepository { get; set; }

        ICartItemRepository CartItemRepository { get; set; }

        IOrderItemRepository OrderItemRepository { get; set; }

        Task SaveChanges();
    }
}
