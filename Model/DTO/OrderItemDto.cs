namespace ArtsShop.Model.DTO
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
}
