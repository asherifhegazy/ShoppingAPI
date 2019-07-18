using OnlineShopping.Data.Domain.Models;
using OnlineShopping.Mapper;
using OnlineShopping.Mapper.Models;
using OnlineShopping.Repositories.UnitOfWork;
using OnlineShopping.Services.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services.Services
{
    public class ProductImagesService : IProductImagesService
    {
        private IUnitOfWork _unitOfWork;

        public ProductImagesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddProductImagesToProduct(ProductImagesDTO productImagesDTO)
        {
            if (productImagesDTO != null)
            {
                var productImages = SMapper.Map(productImagesDTO);
                var result = _unitOfWork.ProductImagesRepository.Add(productImages);
                _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }

        private IEnumerable<ProductImages> GetProductImagesByProductID(int pid)
        {
            return _unitOfWork.ProductImagesRepository.GetProductImagesByProductID(pid);
        }

        public List<bool> RemoveProductImagesFromProductByProductID(int pid)
        {
            var productImages = GetProductImagesByProductID(pid);
            if(productImages != null)
            {
                List<bool> results = new List<bool>();
                for(int index = 0; index < productImages.Count(); index++)
                {
                    var result = _unitOfWork.ProductImagesRepository.Remove(productImages.ElementAt(index));
                    results.Add(result);
                }

                _unitOfWork.SaveChanges();

                return results;
                
            }

            return null;
        }
    }
}
