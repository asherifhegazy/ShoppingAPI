using OnlineShopping.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Repositories.Interfaces
{
    public interface IProductImagesRepository : IRepository<ProductImages>
    {
        IEnumerable<string> GetProductImagesURLsByProductID(int id);

        IEnumerable<ProductImages> GetProductImagesByProductID(int id);
    }
}
