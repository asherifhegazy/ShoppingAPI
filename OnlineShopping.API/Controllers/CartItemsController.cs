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
    public class CartItemsController : ControllerBase
    {
        private readonly IBusinessUnity _businessUnity;

        public CartItemsController(IBusinessUnity businessUnity)
        {
            _businessUnity = businessUnity;
        }

        // GET: api/CartItems/5
        [HttpGet("{uid}")]
        public IEnumerable<CartItemDTO> GetAllCartItemsByUserID(int uid)
        {
            var result = _businessUnity.CartItemService.GetAllCartItemsByUserID(uid);
            return result;
        }

        [HttpGet("count/{uid}")]
        public int GetNumberOfCartItemsByUserID(int uid)
        {
            var result = _businessUnity.CartItemService.GetNumberOfCartItemsByUserID(uid);
            return result;
        }

        [HttpGet("{uid}/{pageIndex}/{pageSize}")]
        public IEnumerable<CartItemDTO> GetCartItemsPagingByUserID(int uid, int pageIndex, int pageSize = 10)
        {
            var result = _businessUnity.CartItemService.GetCartItemsPagingByUserID(uid, pageIndex, pageSize);
            return result;
        }

        [HttpPost]
        public bool AddCartItem([FromBody] CartItemDTO cartItemDTO)
        {
            var result = _businessUnity.CartItemService.AddCartItem(cartItemDTO);
            return result;
        }

        [HttpDelete]
        public bool RemoveCartItem([FromBody] CartItemDTO cartItemDTO)
        {
            var result = _businessUnity.CartItemService.Remove(cartItemDTO);
            return result;
        }

        [HttpDelete("{uid}")]
        public bool EmptyCartItemsByUserID(int uid)
        {
            var result = _businessUnity.CartItemService.EmptyCartItemsByUserID(uid);
            return result;
        }
    }
}