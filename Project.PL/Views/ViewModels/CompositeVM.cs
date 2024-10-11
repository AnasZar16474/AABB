namespace Project.PL.Views.ViewModels
{
    public class CompositeVM
    {
        public IEnumerable<ProductFruitsVM> ProductFruits { get; set; } = null!;
        public IEnumerable<ProductVegetablesVM> ProductVegetables { get; set; } = null!;


    }
}
