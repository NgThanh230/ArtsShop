namespace ArtsShop.Model.DTO
{
    public class OrderCreateDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PaymentMethod { get; set; }
        public string Note { get; set; }
        public int CartId { get; set; } // Id của giỏ hàng để lấy các item
    }
}
