
using MediPlus.Application.DTOs.Slider;

namespace MediPlus.Domain.Interfaces.Services
{
    public interface ISliderService
    {
        Task<ICollection<SliderDto>> GetAllAsync();
        Task<SliderDto> GetByIdAsync(Guid id);
        Task<SliderDto> CreateAsync(CreateSliderDto dto);
        Task RemoveAsync(Guid id);
    }
}
