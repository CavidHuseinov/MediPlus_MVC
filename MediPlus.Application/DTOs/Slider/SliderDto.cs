
using MediPlus.Core.Abstractions;

namespace MediPlus.Application.DTOs.Slider
{
    public record SliderDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
