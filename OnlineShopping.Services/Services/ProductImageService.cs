using OnlineShopping.Data.Domain.Models;
using OnlineShopping.Mapper;
using OnlineShopping.Mapper.Models;
using OnlineShopping.Repositories.UnitOfWork;
using OnlineShopping.Services.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Services.Services
{
    public class ProductImageService : IProductImageService
    {
        private IUnitOfWork _unitOfWork;

        public ProductImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddProductImageToProduct(ProductImageDTO productImageDTO)
        {
            if (productImageDTO != null)
            {
                var productImage = SMapper.Map(productImageDTO);
                var result = await _unitOfWork.ProductImageRepository.Add(productImage);
                await _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }

        private IEnumerable<ProductImage> GetProductImagesByProductID(int pid)
        {
            return _unitOfWork.ProductImageRepository.GetProductImagesByProductID(pid);
        }

        public async Task<List<bool>> RemoveProductImagesFromProductByProductID(int pid)
        {
            var productImages = GetProductImagesByProductID(pid);
            if(productImages != null)
            {
                List<bool> results = new List<bool>();
                for(int index = 0; index < productImages.Count(); index++)
                {
                    var result = _unitOfWork.ProductImageRepository.Remove(productImages.ElementAt(index));
                    results.Add(result);
                }

                await _unitOfWork.SaveChanges();

                return results;
                
            }

            return null;
        }
    }
}
