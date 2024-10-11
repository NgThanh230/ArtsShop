namespace ArtsShop.DTO.ProductDTO
{
    public class OrderItemRequest
    {
        public string ProductId { get; set; }  // Mã sản phẩm (7 ký tự)
        public int Quantity { get; set; }      // Số lượng sản phẩm
    }

}
