
using MediPlus.Application.ViewModels.FileUpload;
using MediPlus.Application.ViewModels.Slider;

namespace MediPlus.Application.ViewModels.FileUploadAndSlider
{
    public record CreateSliderFileUpload
    {
        public CreateFileUploadVM FileUploadVM { get; set; }
        public CreateSliderVM SliderVM { get; set; }
    }
}
