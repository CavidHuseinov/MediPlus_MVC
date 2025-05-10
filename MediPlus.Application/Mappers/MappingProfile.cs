
using AutoMapper;
using MediPlus.Application.ViewModels.FileUpload;
using MediPlus.Application.ViewModels.Slider;
using MediPlus.Domain.Entities;

namespace MediPlus.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Slider
            CreateMap<Slider, SliderVM>().ReverseMap();
            CreateMap<Slider, CreateSliderVM>().ReverseMap();
            #endregion

            #region FileUpload
            CreateMap<CreateFileUploadVM, string>().ReverseMap();
            CreateMap<FileUploadVM, string>().ReverseMap();
            #endregion

            #region FileUploadAndSlider
            CreateMap<CreateFileUploadVM, Slider>().ReverseMap();
            #endregion
        }
    }
}
