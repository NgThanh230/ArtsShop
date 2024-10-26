using ArtsShop.Model.Product;

namespace ArtsShop.Model
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public static Response success(string message, object data = null)
        {
            return new Response { Success = true, Message = message, Data = data };
        }

        public static Response Failure(string message, object data = null)
        {
            return new Response { Success = false, Message = message, Data = data };
        }
    }
}
