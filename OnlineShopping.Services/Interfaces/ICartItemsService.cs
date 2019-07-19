using OnlineShopping.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services.Interfaces
{
    public interface ICartItemsService
    {
        IEnumerable<CartItemsDTO> GetAllCartItemsByUserID(int uid);

        IEnumerable<CartItemsDTO> GetCartItemsPagingByUserID(int uid,int pageIndex, int pageSize = 10);

        bool AddCartItem(CartItemsDTO cartItemsDTO);

        bool RemoveCartItems(CartItemsDTO cartItemsDTO);

        bool EmptyCartItemsListByUserID(int uid);
    }
}
