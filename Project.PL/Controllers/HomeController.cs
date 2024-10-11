using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.DAL.Data;
using Project.DAL.Models;
using Project.PL.Models;
using Project.PL.Views.ViewModels;
using System.Diagnostics;
using System.Security.Policy;

namespace Project.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext dbContext,IMapper mapper)
        {
            _logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var product = dbContext.ProductFruits.ToList();
            var vm=mapper.Map<IEnumerable<ProductFruitsVM>>(product);
            var productA = dbContext.ProductVegetables.ToList();
            var vmA=mapper.Map<IEnumerable<ProductVegetablesVM>>(productA);
            var model = new CompositeVM
            {

                ProductFruits = vm,
              ProductVegetables = vmA

            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    
    }
}
