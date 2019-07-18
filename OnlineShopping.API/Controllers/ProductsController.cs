using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Mapper.Models;
using OnlineShopping.Services.BusinessUnity;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBusinessUnity _businessUnity;

        public ProductsController(IBusinessUnity businessUnity)
        {
            _businessUnity = businessUnity;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var products = _businessUnity.ProductService.GetAllProducts();
            return products;
        }

        // GET: api/Products/1/5
        [HttpGet("{pageIndex}/{pageSize}")]
        public IEnumerable<ProductDTO> GetProductsPaging(int pageIndex, int pageSize)
        {
            var products = _businessUnity.ProductService.GetProductsPaging(pageIndex,pageSize);
            return products;
        }

        // GET: api/Products/filter/200/5000
        [HttpGet("filter/{minPrice}/{maxPrice}")]
        public IEnumerable<ProductDTO> GetProductsFilteredByPriceRange(int minPrice, int maxPrice)
        {
            var products = _businessUnity.ProductService.FilterProductsByPriceRange(minPrice, maxPrice);
            return products;
        }

        // GET: api/Products/filter/200/5000/1/5
        [HttpGet("filter/{minPrice}/{maxPrice}/{pageIndex}/{pageSize}")]
        public IEnumerable<ProductDTO> GetProductsFilteredByPriceRangePaging(int minPrice, int maxPrice, int pageIndex, int pageSize)
        {
            var products = _businessUnity.ProductService.FilterProductsByPriceRangePaging(minPrice, maxPrice, pageIndex, pageSize);
            return products;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ProductDTO GetProduct(int id)
        {
            var product = _businessUnity.ProductService.GetProductByID(id);
            return product;
        }

        // POST: api/Products
        [HttpPost]
        public bool AddProduct([FromBody] ProductDTO product)
        {
            var isAdded = _businessUnity.ProductService.AddProduct(product);
            return isAdded;
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public bool RemoveProduct(int id)
        {
            var isDeleted = _businessUnity.ProductService.RemoveProduct(id);
            return isDeleted;
        }
    }
}