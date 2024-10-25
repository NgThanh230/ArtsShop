using ArtsShop.Model.Product;

namespace ArtsShop.Model
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public int? ErrorCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(bool success, int? errorCode, string message, T data)
        {
            Success = success;
            ErrorCode = errorCode;
            Message = message;
            Data = data;
        }

        public ApiResponse(bool v1, object value, string v2, List<Category> categories)
        {
        }
    }
}
