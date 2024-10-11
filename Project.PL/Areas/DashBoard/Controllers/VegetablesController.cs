using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.DAL.Data;
using Project.DAL.Models;
using Project.PL.Areas.DashBoard.ViewModels.ProductFruitsVM;
using Project.PL.Areas.DashBoard.ViewModels.ProductVegetables;
using Project.PL.Helpers;

namespace Project.PL.Areas.DashBoard.Controllers
{
    [Area("DashBoard")]
    public class VegetablesController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public VegetablesController(IMapper mapper,ApplicationDbContext dbContext) {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductVegetablesCreateVM VM)
        {
            if (!ModelState.IsValid)
            {
                return View(VM);
            }
            VM.ImagName = FilesSetting.UploadFile(VM.Image, "Images");
            var model = mapper.Map<ProductVegetable>(VM);
            dbContext.Add(model);
            dbContext.SaveChanges();
            return Content("Add Succeded");
        }
        [HttpGet]
        public IActionResult Display()
        {
            var product = dbContext.ProductVegetables.ToList();
            var vm = mapper.Map<IEnumerable<ProductVegetablesDisplayVM>>(product);
            return View(vm);
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var product = dbContext.ProductVegetables.Find(Id);
            if (product is null)
            {
                return RedirectToAction(nameof(Display));
            }
            var vm = mapper.Map<ProductVegetablesDeleteVM>(product);
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletedConfirmed(int Id)
        {
            var product = dbContext.ProductVegetables.Find(Id);
            if (product is null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                FilesSetting.DeleteFile(product.ImagName, "Images");
                dbContext.Remove(product);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Display));
            }

        }
        public IActionResult Edit(int Id)
        {
            var product = dbContext.ProductVegetables.Find(Id);
            if (product is null)
            {
                return NotFound();
            }
            else
            {

                return View(mapper.Map<ProductVegetablesEditVM>(product));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductVegetablesEditVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            vm.ImagName = FilesSetting.UploadFile(vm.Image, "Images");
            var product = dbContext.ProductVegetables.Find(vm.Id);

            if (product is null)
            {
                return NotFound();
            }
            else
            {
                FilesSetting.DeleteFile(product.ImagName, "Images");
                mapper.Map(vm, product);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Display));
            }

        }
    }
}
