using OnlineShopping.Data;
using OnlineShopping.Data.Domain.Models;
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopping.Repositories.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public OnlineShoppingContext OnlineShoppingContext
        {
            get
            {
                return Context as OnlineShoppingContext;
            }
        }

        public ProductRepository(OnlineShoppingContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetProductsPaging(int pageIndex, int pageSize = 10)
        {
            if (pageSize < 1)
                pageSize = 1;

            return OnlineShoppingContext.Products
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
        }

        public IEnumerable<Product> FilterProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return OnlineShoppingContext.Products
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice);
        }

        public IEnumerable<Product> FilterProductsByPriceRangePaging(decimal minPrice, decimal maxPrice, int pageIndex, int pageSize = 10)
        {
            if (pageSize < 1)
                pageSize = 1;

            return OnlineShoppingContext.Products
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
