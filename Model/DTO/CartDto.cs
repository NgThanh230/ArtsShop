namespace ArtsShop.Model.DTO
{
    public class CartDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public int PaymentMethod { get; set; }
        public List<CartItemDto> Items { get; set; }
    }

}
