using System;
using System.Collections.Generic;

namespace OnlineShopping.Data.Models
{
    public partial class ProductImages
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
