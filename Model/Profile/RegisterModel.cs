namespace ArtsShop.Model.Profile
{
    public class RegisterRequest
    {
        public string Email { get; set; }             // Địa chỉ email
        public string Password { get; set; }          // Mật khẩu
        public string FullName { get; set; }          // Tên đầy đủ
        public string PhoneNumber { get; set; }       // Số điện thoại
                                                      // Thêm các thuộc tính khác nếu cần thiết
    }


}
