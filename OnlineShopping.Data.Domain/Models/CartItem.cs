﻿using System;
using System.Collections.Generic;

namespace OnlineShopping.Data.Domain.Models
{
    public partial class CartItem
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
