

using MediPlus.Application.ViewModels.Slider;

namespace MediPlus.Domain.Interfaces.Services
{
    public interface ISliderService
    {
        Task<ICollection<SliderVM>> GetAllAsync();
        Task<SliderVM> GetByIdAsync(Guid id);
        Task<SliderVM> CreateAsync(CreateSliderVM dto);
        Task RemoveAsync(Guid id);
    }
}
