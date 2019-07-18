using System;
using System.Collections.Generic;

namespace OnlineShopping.Data.Domain.Models
{
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItems>();
            OrderItems = new HashSet<OrderItems>();
            ProductImages = new HashSet<ProductImages>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<CartItems> CartItems { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
        public virtual ICollection<ProductImages> ProductImages { get; set; }
    }
}
