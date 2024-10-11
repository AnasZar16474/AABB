namespace Project.PL.Areas.DashBoard.ViewModels.ProductVegetables
{
    public class ProductVegetablesCreateVM
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? ImagName { get; set; }
        public IFormFile Image { get; set; } = null!;
        public decimal Price { get; set; }

    }
}
