using System.Net;

namespace MyO_Backend.Communication
{
    public class ApiResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public DateTime RequestDate { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(HttpStatusCode statusCode, string message, T data)
        {
            StatusCode = statusCode;
            RequestDate = DateTime.UtcNow;
            Message = message;
            Data = data;
        }
    }
}
