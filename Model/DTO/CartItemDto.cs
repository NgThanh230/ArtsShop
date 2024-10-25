namespace ArtsShop.Model.DTO
{
    public class CartItemDto
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public string Image { get; set; }
    }
}
