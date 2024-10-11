namespace Project.PL.Areas.DashBoard.ViewModels.ProductVegetables
{
    public class ProductVegetablesDisplayVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImagName { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
