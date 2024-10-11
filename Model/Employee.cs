namespace ArtsShop.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }             // ID của nhân viên
        public string UserName { get; set; }            // Tên đăng nhập
        public string Password { get; set; }            // Mật khẩu
        public string FullName { get; set; }            // Tên đầy đủ
        public string Role { get; set; }                // Vai trò (Admin hoặc Employee)

        // Nhân viên chỉ có thể thay đổi mật khẩu
        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }
    }

}
