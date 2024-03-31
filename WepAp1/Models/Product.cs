using System.ComponentModel.DataAnnotations.Schema;

namespace WepAp1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Price { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category ?Category { get; set; }
    }
}
