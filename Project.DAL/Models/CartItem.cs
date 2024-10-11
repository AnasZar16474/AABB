using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        [ForeignKey("ProductFruit")]
        public int ProductFruitId { get; set; }
        public int Quantity { get; set; }
        public Cart Cart { get; set; }
        public ProductFruit ProductFruit { get; set; }

    }
}
