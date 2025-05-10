using MediPlus.Core.Abstractions;

namespace MediPlus.Application.ViewModels.Slider
{
    public record SliderVM : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
