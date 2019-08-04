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
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        // GET: api/ProductImages
        [HttpPost]
        public async Task<IActionResult> AddProductImagesToProduct([FromBody] ProductImageDTO productImagesDTO)
        {
            var isAdded = await _productImageService.AddProductImageToProduct(productImagesDTO);

            if (!isAdded)
                return NotFound();

            return new JsonResult(isAdded);
        }

        [HttpDelete("{pid}")]
        public async Task<IActionResult> RemoveProductImagesFromProductByProductID(int pid)
        {
            var isRemoved = await _productImageService.RemoveProductImagesFromProductByProductID(pid);

            if (isRemoved == null)
                return NotFound();

            return new JsonResult(isRemoved);
        }
    }
}