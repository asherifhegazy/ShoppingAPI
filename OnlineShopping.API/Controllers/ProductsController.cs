using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Mapper.Models;
using OnlineShopping.Services.Interfaces;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();

            if (products == null)
                return NotFound();

            return new JsonResult(products);
        }

        // GET: api/Products/1/5
        [HttpGet("{pageIndex}/{pageSize}")]
        public IActionResult GetProductsPaging(int pageIndex, int pageSize)
        {
            var products = _productService.GetProductsPaging(pageIndex,pageSize);

            if (products == null)
                return NotFound();

            return new JsonResult(products);
        }

        // GET: api/Products/filter/200/5000
        [HttpGet("filter/{minPrice}/{maxPrice}")]
        public IActionResult GetProductsFilteredByPriceRange(int minPrice, int maxPrice)
        {
            var products = _productService.FilterProductsByPriceRange(minPrice, maxPrice);

            if (products == null)
                return NotFound();

            return new JsonResult(products);
        }

        // GET: api/Products/filter/200/5000/1/5
        [HttpGet("filter/{minPrice}/{maxPrice}/{pageIndex}/{pageSize}")]
        public IActionResult GetProductsFilteredByPriceRangePaging(int minPrice, int maxPrice, int pageIndex, int pageSize)
        {
            var products = _productService.FilterProductsByPriceRangePaging(minPrice, maxPrice, pageIndex, pageSize);

            if (products == null)
                return NotFound();

            return new JsonResult(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetProductByID(id);

            if (product == null)
                return NotFound();

            return new JsonResult(product);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductDTO product)
        {
            var isAdded = _productService.AddProduct(product);

            if (!isAdded)
                return NotFound();

            return new JsonResult(isAdded);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult RemoveProduct(int id)
        {
            var isDeleted = _productService.RemoveProduct(id);

            if (!isDeleted)
                return NotFound();

            return new JsonResult(isDeleted);
        }
    }
}