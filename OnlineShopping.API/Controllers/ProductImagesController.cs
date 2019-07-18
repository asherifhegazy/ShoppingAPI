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
    public class ProductImagesController : ControllerBase
    {
        private readonly IBusinessUnity _businessUnity;

        public ProductImagesController(IBusinessUnity businessUnity)
        {
            _businessUnity = businessUnity;
        }

        // GET: api/ProductImages
        [HttpPost]
        public bool AddProductImagesToProduct([FromBody] ProductImagesDTO productImagesDTO)
        {
            var isAdded = _businessUnity.ProductImagesService.AddProductImagesToProduct(productImagesDTO);
            return isAdded;
        }

        public List<bool> RemoveProductImagesFromProductByProductID(int pid)
        {
            var isRemoved = _businessUnity.ProductImagesService.RemoveProductImagesFromProductByProductID(pid);
            return isRemoved;
        }
    }
}