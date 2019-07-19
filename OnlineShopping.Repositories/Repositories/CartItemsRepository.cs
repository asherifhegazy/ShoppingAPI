using OnlineShopping.Data;
using OnlineShopping.Data.Domain.Models;
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopping.Repositories.Repositories
{
    public class CartItemsRepository : Repository<CartItems>, ICartItemsRepository
    {
        public OnlineShoppingContext OnlineShoppingContext
        {
            get
            {
                return Context as OnlineShoppingContext;
            }
        }

        public CartItemsRepository(OnlineShoppingContext context) : base(context)
        {
        }

        public IEnumerable<CartItems> GetAllCartItemsByUserID(int uid)
        {
            return OnlineShoppingContext.CartItems
                .Where(ci => ci.UserId == uid);
        }

        public IEnumerable<CartItems> GetCartItemsPagingByUserID(int uid, int pageIndex, int pageSize = 10)
        {
            return OnlineShoppingContext.CartItems
                .Where(ci=>ci.UserId == uid)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
        }

        public CartItems GetCartItemsByUserAndProductIDs(int uid, int pid)
        {
            return OnlineShoppingContext.CartItems
                .SingleOrDefault(ci => ci.UserId == uid && ci.ProductId == pid);
        }

        public bool EmptyCartItemsList(IEnumerable<CartItems> cartItemsList)
        {
            if(cartItemsList != null)
            {
                OnlineShoppingContext.RemoveRange(cartItemsList);

                return true;
            }

            return false;
        }

    }
}
