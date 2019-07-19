using System;
using System.Collections.Generic;

namespace OnlineShopping.Mapper.Models
{
    public class CartItemsDTO
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
