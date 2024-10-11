namespace ArtsShop.Model
{
    public class Feedback
    {
        public int Id { get; set; }                  // ID của phản hồi
        public string CustomerId { get; set; }       // ID của khách hàng
        public string Message { get; set; }           // Nội dung phản hồi
        public DateTime CreatedAt { get; set; }       // Ngày tạo phản hồi
    }


}
