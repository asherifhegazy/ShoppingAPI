using OnlineShopping.Data.Models;
using OnlineShopping.Repositories.UnitOfWork;
using OnlineShopping.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Services.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddProduct(Product product)
        {
            if (product != null)
            {
                var result = _unitOfWork.ProductRepository.Add(product);
                _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }

        public IEnumerable<Product> FilterProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var result = _unitOfWork.ProductRepository.FilterProductsByPriceRange(minPrice, maxPrice);
            return result;
        }

        public IEnumerable<Product> FilterProductsByPriceRangePaging(decimal minPrice, decimal maxPrice, int pageIndex, int pageSize = 10)
        {
            var result = _unitOfWork.ProductRepository.FilterProductsByPriceRangePaging(minPrice, maxPrice, pageIndex, pageSize);
            return result;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var result = _unitOfWork.ProductRepository.GetAll();
            return result;
        }

        public Product GetProductByID(int id)
        {
            var result = _unitOfWork.ProductRepository.GetByID(id);
            return result;
        }

        public IEnumerable<Product> GetProductsPaging(int pageIndex, int pageSize = 10)
        {
            var result = _unitOfWork.ProductRepository.GetProductsPaging(pageIndex, pageSize);
            return result;
        }

        public bool RemoveProduct(int id)
        {
            var product = GetProductByID(id);
            if (product != null)
            {
                var result = _unitOfWork.ProductRepository.Remove(product);
                _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }
    }
}
