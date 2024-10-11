namespace ArtsShop.Model
{
    public class Customer
    {
        public string CustomerId { get; set; }       // Customer ID
        public string UserId { get; set; }            // ID người dùng từ Identity
        public string FullName { get; set; }          // Tên đầy đủ
        public string PhoneNumber { get; set; }       // Số điện thoại
                                                      
    }


}
