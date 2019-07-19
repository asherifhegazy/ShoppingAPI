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
        public IEnumerable<CartItemsDTO> GetAllCartItemsByUserID(int uid)
        {
            var result = _businessUnity.CartItemsService.GetAllCartItemsByUserID(uid);
            return result;
        }

        [HttpGet("{uid}/{pageIndex}/{pageSize}")]
        public IEnumerable<CartItemsDTO> GetCartItemsPagingByUserID(int uid, int pageIndex, int pageSize = 10)
        {
            var result = _businessUnity.CartItemsService.GetCartItemsPagingByUserID(uid, pageIndex, pageSize);
            return result;
        }

        [HttpPost]
        public bool AddCartItem([FromBody] CartItemsDTO cartItemsDTO)
        {
            var result = _businessUnity.CartItemsService.AddCartItem(cartItemsDTO);
            return result;
        }

        [HttpDelete]
        public bool RemoveCartItems([FromBody] CartItemsDTO cartItemsDTO)
        {
            var result = _businessUnity.CartItemsService.RemoveCartItems(cartItemsDTO);
            return result;
        }

        [HttpDelete("{uid}")]
        public bool EmptyCartItemsListByUserID(int uid)
        {
            var result = _businessUnity.CartItemsService.EmptyCartItemsListByUserID(uid);
            return result;
        }
    }
}