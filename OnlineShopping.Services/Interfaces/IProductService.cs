using OnlineShopping.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts();

        ProductDTO GetProductByID(int id);

        bool AddProduct(ProductDTO product);

        bool RemoveProduct(int id);

        IEnumerable<ProductDTO> GetProductsPaging(int pageIndex, int pageSize = 10);

        IEnumerable<ProductDTO> FilterProductsByPriceRange(decimal minPrice, decimal maxPrice);

        IEnumerable<ProductDTO> FilterProductsByPriceRangePaging(decimal minPrice, decimal maxPrice, int pageIndex, int pageSize = 10);
    }
}
