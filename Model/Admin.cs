namespace ArtsShop.Model
{
    public class Admin
    {
        public int AdminId { get; set; }                // ID của admin
        public string UserName { get; set; }            // Tên đăng nhập
        public string Password { get; set; }            // Mật khẩu

        // Chỉ quản trị viên mới có quyền quản lý các đối tượng nhân viên và sản phẩm
        public void CreateEmployee(Employee employee) { /* Tạo mới nhân viên */ }
        public void UpdateProduct(Product product) { /* Cập nhật thông tin sản phẩm */ }
        public void ViewOrders(List<Order> orders) { /* Xem danh sách đơn hàng */ }
        public void ViewFeedbacks(List<Feedback> feedbacks) { /* Xem phản hồi của khách hàng */ }
    }

}
