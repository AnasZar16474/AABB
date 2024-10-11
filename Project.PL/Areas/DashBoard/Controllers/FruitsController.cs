using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.DAL.Data;
using Project.DAL.Models;
using Project.PL.Areas.DashBoard.ViewModels.ProductFruitsVM;
using Project.PL.Helpers;
using Project.PL.Views.ViewModels;

namespace Project.PL.Areas.DashBoard.Controllers
{
    [Area("DashBoard")]
    public class FruitsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public FruitsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductFruitsCreateVM VM)
        {
            if (!ModelState.IsValid)
            {
                return View(VM);
            }
            VM.ImagName = FilesSetting.UploadFile(VM.Image, "Images");
            var model = mapper.Map<ProductFruit>(VM);
            dbContext.Add(model);
            dbContext.SaveChanges();
            return Content("Add Succeded");
        }
        [HttpGet]
        public IActionResult Display()
        {
            var product = dbContext.ProductFruits.ToList();
            var vm = mapper.Map<IEnumerable<ProductFruitDisplayVM>>(product);
            return View(vm);
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var product = dbContext.ProductFruits.Find(Id);
            if(product is null)
            {
                return RedirectToAction(nameof(Display));
            }
            var vm = mapper.Map<ProductFruitsDeleteVM>(product);
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletedConfirmed(int Id)
        {
            var product = dbContext.ProductFruits.Find(Id);
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
            var product = dbContext.ProductFruits.Find(Id);
            if (product is null)
            {
                return NotFound();
            }
            else
            {

                return View(mapper.Map<ProductFruitsEditVM>(product));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductFruitsEditVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            vm.ImagName = FilesSetting.UploadFile(vm.Image, "Images");
            var product = dbContext.ProductFruits.Find(vm.Id);
           
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
