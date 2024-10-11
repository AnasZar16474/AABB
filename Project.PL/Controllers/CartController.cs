using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Data;
using Project.DAL.Models;

namespace Project.PL.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;

        public CartController(UserManager<ApplicationUser> userManager,ApplicationDbContext _context)
        {
            this.userManager = userManager;
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            var cart = await context.Carts
                .Include(c => c.CartItem)
                    .ThenInclude(ci => ci.ProductFruit)
                .FirstOrDefaultAsync(c => c.ApplicationUserId == user.Id);

            if (cart == null)
            {
                cart = new Cart { ApplicationUserId = user.Id };
                context.Carts.Add(cart);
                await context.SaveChangesAsync();
            }

            return View(cart);
        }
        public async Task<IActionResult> Add(int Id)
        {
            var user = await userManager.GetUserAsync(User);
            var cart = await context.Carts
                .Include(c => c.CartItem)
                .FirstOrDefaultAsync(c => c.ApplicationUserId == user.Id);

            if (cart == null)
            {
                cart = new Cart { ApplicationUserId = user.Id };
                context.Carts.Add(cart);
                await context.SaveChangesAsync();
            }

            var cartItem = cart.CartItem.FirstOrDefault(ci => ci.ProductFruitId == Id);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    CartId = cart.CartId,
                    ProductFruitId = Id,
                    Quantity = 1
                };
                context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
                context.CartItems.Update(cartItem);
            }

            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
