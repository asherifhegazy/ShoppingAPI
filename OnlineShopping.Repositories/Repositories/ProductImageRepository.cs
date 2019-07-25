using OnlineShopping.Data;
using OnlineShopping.Data.Domain.Models;
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Repositories.Repositories
{
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        public OnlineShoppingContext OnlineShoppingContext
        {
            get
            {
                return Context as OnlineShoppingContext;
            }
        }

        public ProductImageRepository(OnlineShoppingContext context) : base(context)
        {
        }

        public IEnumerable<string> GetProductImagesURLsByProductID(int id)
        {
            return OnlineShoppingContext.ProductImages
                .Where(pi => pi.ProductId == id)
                .Select(pi => pi.ImageUrl);
        }

        public IEnumerable<ProductImage> GetProductImagesByProductID(int id)
        {
            return OnlineShoppingContext.ProductImages
                .Where(pi => pi.ProductId == id);
        }

    }
}
