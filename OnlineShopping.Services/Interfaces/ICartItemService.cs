using OnlineShopping.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services.Interfaces
{
    public interface ICartItemService
    {
        IEnumerable<CartItemDTO> GetAllCartItemsByUserID(int uid);

        IEnumerable<CartItemDTO> GetCartItemsPagingByUserID(int uid,int pageIndex, int pageSize = 10);

        bool AddCartItem(CartItemDTO cartItemDTO);

        bool Remove(CartItemDTO cartItemDTO);

        bool EmptyCartItemsByUserID(int uid);
    }
}
