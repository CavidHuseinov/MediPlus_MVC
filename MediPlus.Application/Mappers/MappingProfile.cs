
using AutoMapper;
using MediPlus.Application.DTOs.Slider;
using MediPlus.Domain.Entities;

namespace MediPlus.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Slider
            CreateMap<Slider, SliderDto>().ReverseMap();
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            #endregion
        }
    }
}
