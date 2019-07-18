using System;
using System.Collections.Generic;

namespace OnlineShopping.Data.Domain.Models
{
    public partial class User
    {
        public User()
        {
            CartItems = new HashSet<CartItems>();
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<CartItems> CartItems { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
