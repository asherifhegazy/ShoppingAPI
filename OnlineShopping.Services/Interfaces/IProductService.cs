using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductByID(int id);

        bool AddProduct(Product product);

        bool RemoveProduct(int id);

        IEnumerable<Product> GetProductsPaging(int pageIndex, int pageSize = 10);

        IEnumerable<Product> FilterProductsByPriceRange(decimal minPrice, decimal maxPrice);

        IEnumerable<Product> FilterProductsByPriceRangePaging(decimal minPrice, decimal maxPrice, int pageIndex, int pageSize = 10);
    }
}
