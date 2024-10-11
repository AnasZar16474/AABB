namespace Project.PL.Areas.DashBoard.ViewModels.ProductFruitsVM
{
    public class ProductFruitsEditVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IFormFile Image { get; set; } = null!;
        public string? ImagName { get; set; }
        public decimal Price { get; set; }
    }
}
