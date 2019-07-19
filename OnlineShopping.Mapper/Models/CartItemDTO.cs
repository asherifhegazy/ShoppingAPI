using System;
using System.Collections.Generic;

namespace OnlineShopping.Mapper.Models
{
    public class CartItemDTO
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
