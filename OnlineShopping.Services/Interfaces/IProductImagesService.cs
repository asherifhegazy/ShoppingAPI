using OnlineShopping.Mapper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services.Interfaces
{
    public interface IProductImagesService
    {
        bool AddProductImagesToProduct(ProductImagesDTO productImagesDTO);

        List<bool> RemoveProductImagesFromProductByProductID(int pid);
    }
}
