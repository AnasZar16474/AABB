using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Models
{
    public class ApplicationUser :IdentityUser
    {
        public Cart cart { get; set; }  
        public IEnumerable<Order>  Order { get; set; }

    }
}
