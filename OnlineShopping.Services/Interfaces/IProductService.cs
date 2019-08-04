using OnlineShopping.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts();

        ProductDTO GetProductByID(int id);

        Task<bool> AddProduct(ProductDTO productDTO);

        Task<bool> RemoveProduct(int id);

        IEnumerable<ProductDTO> GetProductsPaging(int pageIndex, int pageSize = 10);

        IEnumerable<ProductDTO> FilterProductsByPriceRange(decimal minPrice, decimal maxPrice);

        IEnumerable<ProductDTO> FilterProductsByPriceRangePaging(decimal minPrice, decimal maxPrice, int pageIndex, int pageSize = 10);
    }
}
