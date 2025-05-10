
using MediPlus.Core.Abstractions;

namespace MediPlus.Domain.Entities
{
    public class Slider : BaseEntity
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? Url { get; set; }
    }
}
