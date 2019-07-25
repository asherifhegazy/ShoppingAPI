using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Mapper.Models;
using OnlineShopping.Services.BusinessUnity;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IBusinessUnity _businessUnity;

        public OrdersController(IBusinessUnity businessUnity)
        {
            _businessUnity = businessUnity;
        }

        //[HttpPost("{uid}")]
        //public bool AddOrderByUserID(int uid, [FromBody] IEnumerable<OrderItemDTO> orderItemsDTO)
        //{
        //    var IsAdded = _businessUnity.OrderService.AddOrderByUserID(uid, orderItemsDTO);
        //    _businessUnity.CartItemService.GetAllCartItemsByUserID(uid);
        //    if (IsAdded)
        //    {
        //        var result = _businessUnity.CartItemService.EmptyCartItemsByUserID(uid);
        //    }
        //}

        [HttpPost("{uid}")]
        public bool AddOrderByUserID(int uid)
        {
            var IsAdded = _businessUnity.OrderService.AddOrderByUserID(uid);

            if (!IsAdded)
                return false;

            var result = _businessUnity.CartItemService.EmptyCartItemsByUserID(uid);

            return result;
        }

        //[HttpGet("{id}")]
        //public OrderDTO GetOrderByID(int id)
        //{
        //    var result = _businessUnity.OrderService.GetOrderByID(id);

        //    return result;
        //}

        [HttpGet("{oid}")]
        public IEnumerable<OrderItemDTO> GetOrderItems(int oid)
        {
            var result = _businessUnity.OrderService.GetOrderItems(oid);

            return result;
        }

        [HttpGet("user/{uid}")]
        public IEnumerable<OrderDTO> GetAllOrdersByUserID(int uid)
        {
            var result = _businessUnity.OrderService.GetAllOrdersByUserID(uid);

            return result;
        }
    }
}