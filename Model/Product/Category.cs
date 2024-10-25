using System.ComponentModel.DataAnnotations;

namespace ArtsShop.Model.Product
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Key { get; set; }

        public string Type { get; set; } = "category"; // Default value

        public bool IsAvailable { get; set; } = true; // Default value
    }

}
