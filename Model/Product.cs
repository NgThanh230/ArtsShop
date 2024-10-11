using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ArtsShop.Model
{
    public class Product
    {
        [Required]
        public string ProductId { get; set; }           // 7 ký tự (2 chữ mã sản phẩm + 5 chữ số)
        public string Name { get; set; }                // Tên sản phẩm
        public string Description { get; set; }         // Mô tả sản phẩm
        public decimal Price { get; set; }              // Giá sản phẩm
        public int StockQuantity { get; set; }          // Số lượng tồn kho
        public string Category { get; set; }            // Loại sản phẩm (Arts, Gift Articles, Greeting Cards, Hand Bags...)

        // Phương thức cập nhật số lượng tồn kho
        public void UpdateStock(int quantity)
        {
            StockQuantity = quantity;
        }
    }


}
