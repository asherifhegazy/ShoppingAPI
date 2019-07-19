using OnlineShopping.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Repositories.Interfaces
{
    public interface ICartItemsRepository : IRepository<CartItems>
    {
        IEnumerable<CartItems> GetAllCartItemsByUserID(int uid);

        IEnumerable<CartItems> GetCartItemsPagingByUserID(int uid, int pageIndex, int pageSize = 10);

        CartItems GetCartItemsByUserAndProductIDs(int uid, int pid);

        bool EmptyCartItemsList(IEnumerable<CartItems> cartItemsList);
    }
}
