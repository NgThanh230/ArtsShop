namespace ArtsShop.Model
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }             // Mã sản phẩm trong đơn hàng
        public string ProductId { get; set; }            // Mã sản phẩm (7 ký tự)
        public int Quantity { get; set; }                // Số lượng sản phẩm
        public decimal Price { get; set; }               // Giá sản phẩm tại thời điểm đặt hàng
        public decimal Subtotal => Quantity * Price;     // Tổng tiền cho sản phẩm này
    }

}
