using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.Data;
using OnlineShopping.Repositories.Interfaces;
using OnlineShopping.Repositories.Repositories;

namespace OnlineShopping.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public OnlineShoppingContext Context { get; private set; }

        public UnitOfWork(OnlineShoppingContext context, IUserRepository userRepository, IOrderRepository orderRepository
            , IProductRepository productRepository, IProductImageRepository productImageRepository
            , ICartItemRepository cartItemRepository, IOrderItemRepository orderItemRepository)
        {
            Context = context;
            UserRepository = userRepository;
            OrderRepository = orderRepository;
            ProductRepository = productRepository;
            ProductImageRepository = productImageRepository;
            CartItemRepository = cartItemRepository;
            OrderItemRepository= orderItemRepository;
        }

        public IUserRepository UserRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IProductImageRepository ProductImageRepository { get; set; }
        public ICartItemRepository CartItemRepository { get; set; }
        public IOrderItemRepository OrderItemRepository { get; set; }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();
        }
    }
}
