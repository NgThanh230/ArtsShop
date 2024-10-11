namespace ArtsShop.Model
{
    public class Stock
    {
        public string ProductId { get; set; }           // ID sản phẩm
        public int QuantityInStock { get; set; }        // Số lượng còn trong kho
        public DateTime LastUpdated { get; set; }       // Ngày cập nhật kho hàng gần nhất
    }

}
