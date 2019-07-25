using OnlineShopping.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services.Interfaces
{
    public interface IProductImageService
    {
        bool AddProductImageToProduct(ProductImageDTO productImageDTO);

        List<bool> RemoveProductImagesFromProductByProductID(int pid);
    }
}
