using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Mapper.Models;
using OnlineShopping.Services.Interfaces;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICartItemService _cartItemService;

        public OrdersController(IOrderService orderService, ICartItemService cartItemService)
        {
            _orderService = orderService;
            _cartItemService = cartItemService;
        }

        [HttpPost("{uid}")]
        public async Task<IActionResult> AddOrderByUserID(int uid)
        {
            var IsAdded = await _orderService.AddOrderByUserID(uid);

            if (!IsAdded)
                return NotFound();

            return new JsonResult(IsAdded);
        }

        [HttpGet("{oid}")]
        public IActionResult GetOrderItems(int oid)
        {
            var orders = _orderService.GetOrderItems(oid);

            if (orders == null)
                return NotFound();

            return new JsonResult(orders);
        }

        [HttpGet("user/{uid}")]
        public IActionResult GetAllOrdersByUserID(int uid)
        {
            var orders = _orderService.GetAllOrdersByUserID(uid);

            if (orders == null)
                return NotFound();

            return new JsonResult(orders);
        }
    }
}