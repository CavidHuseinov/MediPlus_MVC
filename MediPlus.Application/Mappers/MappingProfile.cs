
using AutoMapper;
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
        }
    }
}
