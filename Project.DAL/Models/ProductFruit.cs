using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Models
{
    public class ProductFruit
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImagName { get; set; } = null!;
        public decimal Price { get; set; }
        public IEnumerable<CartItem> CartItem {get; set;}
        public IEnumerable<OrderItem> OrderItem { get; set; }

    }
}
