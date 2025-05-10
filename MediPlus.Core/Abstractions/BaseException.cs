
namespace MediPlus.Core.Abstractions
{
    public abstract class BaseException : Exception
    {
        public int StatusCode { get; set; }
        public BaseException(string? message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
