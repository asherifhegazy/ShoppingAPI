using System;
using System.Collections.Generic;

namespace OnlineShopping.Mapper.Models
{
    public class OrderItemsDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
