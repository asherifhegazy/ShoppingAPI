using OnlineShopping.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Services.Interfaces
{
    public interface IProductImageService
    {
        Task<bool> AddProductImageToProduct(ProductImageDTO productImageDTO);

        Task<List<bool>> RemoveProductImagesFromProductByProductID(int pid);
    }
}
