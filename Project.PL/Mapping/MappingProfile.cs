using AutoMapper;
using Project.DAL.Models;
using Project.PL.Areas.DashBoard.ViewModels.ProductFruitsVM;
using Project.PL.Areas.DashBoard.ViewModels.ProductVegetables;
using Project.PL.Views.ViewModels;

namespace Project.PL.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<ProductFruitsCreateVM,ProductFruit>();
            CreateMap<ProductFruit, ProductFruitsVM>();
            CreateMap<ProductFruit, ProductFruitDisplayVM > ();
            CreateMap<ProductFruit, ProductFruitsDeleteVM>();
            CreateMap<ProductFruit, ProductFruitsEditVM>().ReverseMap();
            CreateMap<ProductVegetable, ProductVegetablesVM>();
            CreateMap<ProductVegetablesCreateVM, ProductVegetable>();
            CreateMap<ProductVegetable, ProductVegetablesDisplayVM>();
            CreateMap<ProductVegetable, ProductVegetablesDeleteVM>();
            CreateMap<ProductVegetable, ProductVegetablesEditVM>().ReverseMap();



        }
    }
}
