namespace ArtsShop.Model.Profile
{
    public class ChangeUserRoleRequest
    {
        public int UserId { get; set; }  // ID của người dùng
        public string NewRole { get; set; } // Vai trò mới
    }
}
