using System;
using System.Collections.Generic;

namespace OnlineShopping.Data.Domain.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
