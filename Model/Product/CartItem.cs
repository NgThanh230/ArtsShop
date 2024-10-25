using System.ComponentModel.DataAnnotations;

namespace ArtsShop.Model.Product
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
}
