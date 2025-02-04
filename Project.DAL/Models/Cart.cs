﻿using Project.DAL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Models
{
    public class Cart
    {
        public int CartId { get; set; } 
        public DateTime CreatedAt { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationDbContext Context { get; set; }
        public IEnumerable<CartItem>  CartItem { get; set; }

    }
}
