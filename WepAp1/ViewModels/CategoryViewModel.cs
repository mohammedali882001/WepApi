namespace WepAp1.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> ProductsName { get; set; } = new List<string>(); // Initialize ProductsName as a new List<string>
    }
}
