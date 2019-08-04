using OnlineShopping.Data.Domain.Models;
using OnlineShopping.Mapper;
using OnlineShopping.Mapper.Models;
using OnlineShopping.Repositories.UnitOfWork;
using OnlineShopping.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Services.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddOrderByUserID(int uid)
        {
            var newOrder = new Order { UserId = uid };
            var result = await _unitOfWork.OrderRepository.Add(newOrder);
            if (result)
            {
                // to have ID for newOrder
                await _unitOfWork.SaveChanges();

                var cartItems = _unitOfWork.CartItemRepository.GetAllCartItemsByUserID(uid)
                    .Where(ci => ci.Product.Quantity >= ci.Quantity);

                if (cartItems != null)
                {
                    var isCartEmptied = EmptyCartItemsByUserID(cartItems);

                    if (isCartEmptied)
                    {
                        var orderItems = SMapper.MapTypes(cartItems.ToList())
                            .Select(oi =>
                            {
                                oi.OrderId = newOrder.Id;
                                oi.Product.Quantity -= oi.Quantity;

                                return oi;
                            });

                        result = await _unitOfWork.OrderItemRepository.AddOrderItems(orderItems);

                        await _unitOfWork.SaveChanges();

                        return result;
                    }
                }
            }

            return false;
        }

        private bool EmptyCartItemsByUserID(IEnumerable<CartItem> cartItems)
        {
            List<bool> results = new List<bool>();

            foreach (var item in cartItems)
            {
                var result = _unitOfWork.CartItemRepository.Remove(item);

                results.Add(result);
            }

            return results.Any(r => r.Equals(true));
        }


        public IEnumerable<OrderDTO> GetAllOrdersByUserID(int uid)
        {
            var orders = _unitOfWork.OrderRepository.GetAllOrdersByUserID(uid);
            var ordersDTO = SMapper.Map(orders.ToList());

            return ordersDTO;
        }

        public OrderDTO GetOrderByID(int id)
        {
            var order = _unitOfWork.OrderRepository.GetOrderByID(id);
            var orderDTO = SMapper.Map(order);

            return orderDTO;
        }

        public IEnumerable<OrderItemDTO> GetOrderItems(int oid)
        {
            var orderItems = _unitOfWork.OrderItemRepository.GetOrderItems(oid);
            var orderItemsDTO = SMapper.Map(orderItems.ToList());

            return orderItemsDTO;
        }
    }
}
