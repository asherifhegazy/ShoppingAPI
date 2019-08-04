using OnlineShopping.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Services.Interfaces
{
    public interface ICartItemService
    {
        IEnumerable<CartItemDTO> GetAllCartItemsByUserID(int uid);

        IEnumerable<CartItemDTO> GetCartItemsPagingByUserID(int uid, int pageIndex, int pageSize = 10);

        Task<bool> AddCartItem(CartItemDTO cartItemDTO);

        Task<bool> Remove(CartItemDTO cartItemDTO);

        int GetNumberOfCartItemsByUserID(int uid);
    }
}
