using OnlineShopping.Data.Domain.Models;
using OnlineShopping.Mapper;
using OnlineShopping.Mapper.Models;
using OnlineShopping.Repositories.UnitOfWork;
using OnlineShopping.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopping.Services.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddOrderByUserID(int uid, IEnumerable<OrderItemDTO> orderItemsDTO)
        {
            var newOrder = new Order { UserId = uid };
            var result = _unitOfWork.OrderRepository.Add(newOrder);
            if (result)
            {
                // to have ID for newOrder
                _unitOfWork.SaveChanges();

                var orderItems = SMapper.Map(orderItemsDTO.ToList())
                    .Select(oi =>
                    {
                        oi.OrderId = newOrder.Id;

                        return oi;
                    });

                result = _unitOfWork.OrderItemRepository.AddOrderItems(orderItems);

                _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }

        public bool AddOrderByUserID(int uid)
        {
            var newOrder = new Order { UserId = uid };
            var result = _unitOfWork.OrderRepository.Add(newOrder);
            if (result)
            {
                // to have ID for newOrder
                _unitOfWork.SaveChanges();

                var cartItems = _unitOfWork.CartItemRepository.GetAllCartItemsByUserID(uid)
                    .Where(ci => ci.Product.Quantity >= ci.Quantity);

                if (cartItems != null)
                {
                    var orderItems = SMapper.MapTypes(cartItems.ToList())
                        .Select(oi =>
                        {
                            oi.OrderId = newOrder.Id;
                            oi.Product.Quantity -= oi.Quantity;

                            return oi;
                        });

                    result = _unitOfWork.OrderItemRepository.AddOrderItems(orderItems);

                    _unitOfWork.SaveChanges();

                    return result;
                }
            }

            return false;
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
