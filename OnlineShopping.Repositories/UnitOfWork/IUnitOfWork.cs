using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; set; }

        IOrderRepository OrderRepository { get; set; }

        IProductRepository ProductRepository { get; set; }

        IProductImagesRepository ProductImagesRepository { get; set; }

        ICartItemsRepository CartItemsRepository { get; set; }

        IOrderItemsRepository OrderItemsRepository { get; set; }

        void SaveChanges();
    }
}
