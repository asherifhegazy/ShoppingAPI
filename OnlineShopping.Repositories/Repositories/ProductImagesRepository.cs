using OnlineShopping.Data;
using OnlineShopping.Data.Domain.Models;
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Repositories.Repositories
{
    public class ProductImagesRepository : Repository<ProductImages>, IProductImagesRepository
    {
        public OnlineShoppingContext OnlineShoppingContext
        {
            get
            {
                return Context as OnlineShoppingContext;
            }
        }

        public ProductImagesRepository(OnlineShoppingContext context) : base(context)
        {
        }

        public IEnumerable<string> GetProductImagesURLsByProductID(int id)
        {
            return OnlineShoppingContext.ProductImages
                .Where(pi => pi.ProductId == id)
                .Select(pi => pi.ImageUrl);
        }

        public IEnumerable<ProductImages> GetProductImagesByProductID(int id)
        {
            return OnlineShoppingContext.ProductImages
                .Where(pi => pi.ProductId == id);
        }

    }
}
