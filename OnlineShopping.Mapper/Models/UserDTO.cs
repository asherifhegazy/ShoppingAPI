using System;
using System.Collections.Generic;

namespace OnlineShopping.Mapper.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
