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
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemsController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        // GET: api/CartItems/5
        [HttpGet("{uid}")]
        public IActionResult GetAllCartItemsByUserID(int uid)
        {
            var cartItems = _cartItemService.GetAllCartItemsByUserID(uid);

            if (cartItems == null)
                return NotFound();

            return new JsonResult(cartItems);
        }

        [HttpGet("count/{uid}")]
        public IActionResult GetNumberOfCartItemsByUserID(int uid)
        {
            var count = _cartItemService.GetNumberOfCartItemsByUserID(uid);

            return new JsonResult(count);
        }

        [HttpGet("{uid}/{pageIndex}/{pageSize}")]
        public IActionResult GetCartItemsPagingByUserID(int uid, int pageIndex, int pageSize = 10)
        {
            var cartItems = _cartItemService.GetCartItemsPagingByUserID(uid, pageIndex, pageSize);

            if (cartItems == null)
                return NotFound();

            return new JsonResult(cartItems);
        }

        [HttpPost]
        public IActionResult AddCartItem([FromBody] CartItemDTO cartItemDTO)
        {
            var isAdded = _cartItemService.AddCartItem(cartItemDTO);

            if (!isAdded)
                return NotFound();

            return new JsonResult(isAdded);
        }

        [HttpDelete]
        public IActionResult RemoveCartItem([FromBody] CartItemDTO cartItemDTO)
        {
            var isDeleted = _cartItemService.Remove(cartItemDTO);

            if (!isDeleted)
                return NotFound();

            return new JsonResult(isDeleted);
        }
    }
}