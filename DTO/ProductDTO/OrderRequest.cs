namespace ArtsShop.DTO.ProductDTO
{
    public class OrderRequest
    {
        public string ProductId { get; set; }          // ID sản phẩm
        public int Quantity { get; set; }               // Số lượng sản phẩm
        public string PaymentType { get; set; }        // Loại hình thanh toán
    }


}
