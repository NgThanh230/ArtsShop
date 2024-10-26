namespace ArtsShop.Model
{
    public class Response<T>
    {
        public bool isSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public Response(bool Success, string message, T data)
        {
            isSuccess = Success;
            Message = message;
            Data = data;
        }
    }

}
