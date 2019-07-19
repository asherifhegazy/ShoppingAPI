using OnlineShopping.Mapper;
using OnlineShopping.Mapper.Models;
using OnlineShopping.Repositories.UnitOfWork;
using OnlineShopping.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool AddProduct(ProductDTO productDTO)
        {
            if (productDTO != null)
            {
                var product = SMapper.Map(productDTO);
                var result = _unitOfWork.ProductRepository.Add(product);
                _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }

        public IEnumerable<ProductDTO> FilterProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var result = _unitOfWork.ProductRepository.FilterProductsByPriceRange(minPrice, maxPrice);
            var productsDTO = SMapper.Map(result.ToList());

            //productsDTO = AddProductImagesToProductDTOList(productsDTO);

            return productsDTO;
        }

        public IEnumerable<ProductDTO> FilterProductsByPriceRangePaging(decimal minPrice, decimal maxPrice, int pageIndex, int pageSize = 10)
        {
            var result = _unitOfWork.ProductRepository.FilterProductsByPriceRangePaging(minPrice, maxPrice, pageIndex, pageSize);
            var productsDTO = SMapper.Map(result.ToList());

            //productsDTO = AddProductImagesToProductDTOList(productsDTO);

            return productsDTO;
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var result = _unitOfWork.ProductRepository.GetAll();
            var productsDTO = SMapper.Map(result.ToList());

            //productsDTO = AddProductImagesToProductDTOList(productsDTO);

            return productsDTO;
        }

        public ProductDTO GetProductByID(int id)
        {
            var result = _unitOfWork.ProductRepository.GetByID(id);
            var productDTO = SMapper.Map(result);

            productDTO = AddProductImagesToProductDTO(productDTO);

            return productDTO;
        }

        public IEnumerable<ProductDTO> GetProductsPaging(int pageIndex, int pageSize = 10)
        {
            var result = _unitOfWork.ProductRepository.GetProductsPaging(pageIndex, pageSize);
            var productsDTO = SMapper.Map(result.ToList());

            //productsDTO = AddProductImagesToProductDTOList(productsDTO);

            return productsDTO;
        }

        public bool RemoveProduct(int id)
        {
            var productDTO = GetProductByID(id);
            var product = SMapper.Map(productDTO);

            if (product != null)
            {
                var result = _unitOfWork.ProductRepository.Remove(product);
                _unitOfWork.SaveChanges();

                return result;
            }

            return false;
        }

        private ProductDTO AddProductImagesToProductDTO(ProductDTO productDTO)
        {
            productDTO.Images = _unitOfWork.ProductImagesRepository.GetProductImagesURLsByProductID(productDTO.Id);

            return productDTO;
        }

        //private ICollection<ProductDTO> AddProductImagesToProductDTOList(ICollection<ProductDTO> productsDTO)
        //{
        //    productsDTO.Select(p =>
        //    {
        //        p.Images = _unitOfWork.ProductImagesRepository.GetProductImagesURLsByProductID(p.Id);

        //        return p;
        //    });

        //    return productsDTO;
        //}
    }
}
