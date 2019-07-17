using System;
using System.Collections.Generic;
using System.Text;
using OnlineShopping.Data;
using OnlineShopping.Repositories.Interfaces;
using OnlineShopping.Repositories.Repositories;

namespace OnlineShopping.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public OnlineShoppingContext Context { get; private set; } = new OnlineShoppingContext();

        public UnitOfWork()
        {
            UserRepository = new UserRepository(Context);
            OrderRepository = new OrderRepository(Context);
            ProductRepository = new ProductRepository(Context);
            ProductImagesRepository = new ProductImagesRepository(Context);
            CartItemsRepository = new CartItemsRepository(Context);
            OrderItemsRepository= new OrderItemsRepository(Context);
        }

        public IUserRepository UserRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IProductImagesRepository ProductImagesRepository { get; set; }
        public ICartItemsRepository CartItemsRepository { get; set; }
        public IOrderItemsRepository OrderItemsRepository { get; set; }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
