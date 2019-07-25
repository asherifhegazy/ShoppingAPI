using OnlineShopping.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Repositories.Interfaces
{
    public interface IProductImageRepository : IRepository<ProductImage>
    {
        IEnumerable<string> GetProductImagesURLsByProductID(int id);

        IEnumerable<ProductImage> GetProductImagesByProductID(int id);
    }
}
