namespace ArtsShop.Model
{
    public class Order
    {
        public string OrderId { get; set; }            // ID đơn hàng (16 ký tự)
        public string CustomerId { get; set; }         // ID khách hàng
        public DateTime OrderDate { get; set; }        // Ngày đặt hàng
        public string ProductId { get; set; }          // ID sản phẩm
        public int Quantity { get; set; }               // Số lượng sản phẩm
        public decimal TotalAmount { get; set; }       // Tổng số tiền
        public string PaymentType { get; set; }        // Loại hình thanh toán (Credit Card, Cheque, VPP)
        public string Status { get; set; }              // Trạng thái đơn hàng
    }



}
