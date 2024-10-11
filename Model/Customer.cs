namespace ArtsShop.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }             // ID khách hàng
        public string UserName { get; set; }            // Tên đăng nhập
        public string Password { get; set; }            // Mật khẩu
        public string FullName { get; set; }            // Tên đầy đủ
        public string Address { get; set; }             // Địa chỉ giao hàng
        public string Email { get; set; }               // Email liên hệ
        public string PhoneNumber { get; set; }         // Số điện thoại liên hệ

        // Khách hàng có thể thay đổi mật khẩu
        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }
    }

}
