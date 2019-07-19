using System;
using System.Collections.Generic;

namespace OnlineShopping.Mapper.Models
{
    public class ProductImageDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
