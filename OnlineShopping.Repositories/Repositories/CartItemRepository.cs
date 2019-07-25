using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data;
using OnlineShopping.Data.Domain.Models;
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopping.Repositories.Repositories
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public OnlineShoppingContext OnlineShoppingContext
        {
            get
            {
                return Context as OnlineShoppingContext;
            }
        }

        public CartItemRepository(OnlineShoppingContext context) : base(context)
        {
        }

        public IEnumerable<CartItem> GetAllCartItemsByUserID(int uid)
        {
            return OnlineShoppingContext.CartItems
                .Include(ci => ci.Product)
                .Where(ci => ci.UserId == uid);
        }

        public IEnumerable<CartItem> GetCartItemsPagingByUserID(int uid, int pageIndex, int pageSize = 10)
        {
            if (pageSize < 1)
                pageSize = 1;

            return OnlineShoppingContext.CartItems
                .Include(ci => ci.Product)
                .Where(ci=>ci.UserId == uid)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
        }

        public CartItem GetCartItemByUserAndProductIDs(int uid, int pid)
        {
            return OnlineShoppingContext.CartItems
                .Include(ci => ci.Product)
                .SingleOrDefault(ci => ci.UserId == uid && ci.ProductId == pid);
        }

        //public bool EmptyCartItems(IEnumerable<CartItem> cartItems)
        //{
        //    if(cartItems != null)
        //    {
        //        OnlineShoppingContext.RemoveRange(cartItems);

        //        return true;
        //    }

        //    return false;
        //}

    }
}
