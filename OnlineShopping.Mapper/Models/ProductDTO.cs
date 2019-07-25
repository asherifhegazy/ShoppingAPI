using System;
using System.Collections.Generic;

namespace OnlineShopping.Mapper.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePosterUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
