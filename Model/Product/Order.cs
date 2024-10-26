using ArtsShop.Model.Profile;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtsShop.Model.Product
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Status { get; set; } // Có thể là enum cho các trạng thái như "New", "Shipped", "Delivered", v.v.
        public string PaymentMethod { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public string Note { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
