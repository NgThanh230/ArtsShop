namespace ArtsShop.Model
{
    public class Order
    {
        public string OrderNumber { get; set; }         // Số đơn hàng 16 chữ số (1 chữ số loại giao hàng, 7 chữ số ID sản phẩm, 8 chữ số ID đơn hàng)
        public int CustomerId { get; set; }             // ID khách hàng
        public string ProductId { get; set; }           // ID sản phẩm
        public int Quantity { get; set; }               // Số lượng sản phẩm
        public decimal TotalPrice { get; set; }         // Tổng giá trị đơn hàng
        public string PaymentType { get; set; }         // Loại thanh toán (Credit Card, Cheque, VPP)
        public bool IsPaymentCleared { get; set; }      // Xác nhận thanh toán (chỉ áp dụng với Credit Card, Cheque)
        public string DeliveryType { get; set; }        // Loại giao hàng (1 chữ số: VPP, Chuyển phát nhanh...)
        public DateTime OrderDate { get; set; }         // Ngày đặt hàng
        public DateTime? DispatchDate { get; set; }     // Ngày giao hàng (nếu đã giao)

        // Trạng thái đơn hàng (đã hủy nếu chưa được gửi)
        public bool IsCancelled { get; set; }

        public void CancelOrder()
        {
            if (DispatchDate == null)
            {
                IsCancelled = true;
            }
        }
    }

}
