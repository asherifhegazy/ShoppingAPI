using OnlineShopping.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Repositories.Interfaces
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        IEnumerable<CartItem> GetAllCartItemsByUserID(int uid);

        IEnumerable<CartItem> GetCartItemsPagingByUserID(int uid, int pageIndex, int pageSize = 10);

        CartItem GetCartItemByUserAndProductIDs(int uid, int pid);

        bool EmptyCartItems(IEnumerable<CartItem> cartItemList);
    }
}
