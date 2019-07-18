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
        public OnlineShoppingContext Context { get; private set; }

        public UnitOfWork(OnlineShoppingContext context, IUserRepository userRepository, IOrderRepository orderRepository
            , IProductRepository productRepository, IProductImagesRepository productImagesRepository
            , ICartItemsRepository cartItemsRepository, IOrderItemsRepository orderItemsRepository)
        {
            Context = context;
            UserRepository = userRepository;
            OrderRepository = orderRepository;
            ProductRepository = productRepository;
            ProductImagesRepository = productImagesRepository;
            CartItemsRepository = cartItemsRepository;
            OrderItemsRepository= orderItemsRepository;
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
