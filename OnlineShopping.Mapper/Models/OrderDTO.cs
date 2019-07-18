using System;
using System.Collections.Generic;

namespace OnlineShopping.Mapper.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
