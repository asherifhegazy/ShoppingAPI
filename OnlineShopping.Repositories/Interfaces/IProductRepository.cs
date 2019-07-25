using OnlineShopping.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductsPaging(int pageIndex, int pageSize = 10);

        IEnumerable<Product> FilterProductsByPriceRange(decimal minPrice, decimal maxPrice);

        IEnumerable<Product> FilterProductsByPriceRangePaging(decimal minPrice, decimal maxPrice, int pageIndex, int pageSize = 10);
    }
}
