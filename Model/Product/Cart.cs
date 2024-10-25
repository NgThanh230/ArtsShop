using ArtsShop.Model.Profile;
using System.ComponentModel.DataAnnotations;

namespace ArtsShop.Model.Product
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public int? PaymentMethod { get; set; }

        // Có thể có một danh sách các sản phẩm trong giỏ hàng
        public List<CartItem> Items { get; set; }
    }



}
