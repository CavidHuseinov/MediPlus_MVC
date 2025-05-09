
using MediPlus.Core.Abstractions;

namespace MediPlus.Application.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string? message) : base(message, 404)
        {
        }
    }
}
