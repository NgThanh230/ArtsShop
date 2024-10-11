namespace ArtsShop.Model
{
    public class Payment
    {
        public int PaymentId { get; set; }              // ID thanh toán
        public string OrderNumber { get; set; }         // Số đơn hàng liên quan
        public string PaymentType { get; set; }         // Loại thanh toán (Credit Card, Cheque, VPP)
        public decimal Amount { get; set; }             // Số tiền thanh toán
        public bool IsCleared { get; set; }             // Xác nhận thanh toán (dùng cho Credit Card và Cheque)

        // Chi tiết thanh toán (nếu có) như thông tin Credit Card, Cheque...
        public string PaymentDetails { get; set; }
    }


}
