using System;
using System.Collections.Generic;

namespace OnlineShopping.Mapper.Models
{
    public class ProductImagesDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
