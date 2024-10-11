namespace ArtsShop.Model
{
    public class Feedback
    {
        public int FeedbackId { get; set; }             // ID phản hồi
        public int CustomerId { get; set; }             // ID khách hàng
        public string Comments { get; set; }            // Nội dung phản hồi
        public DateTime Date { get; set; }              // Ngày gửi phản hồi
    }

}
