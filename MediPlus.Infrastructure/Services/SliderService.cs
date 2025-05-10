
using AutoMapper;
using MediPlus.Application.Exceptions;
using MediPlus.Application.ViewModels.Slider;
using MediPlus.Domain.Entities;
using MediPlus.Domain.Interfaces.Services;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.IRepositories.Generics;
using MediPlus.Domain.Settings;
using MediPlus.Persistance.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace MediPlus.Infrastructure.Services
{
    public class SliderService : ISliderService
    {
        private readonly IQueryRepo<Slider> _query;
        private readonly ISliderRepo _command;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memory;
        private readonly IUnitOfWork _save;
        private readonly string cacheKeyPrefix = "slider_";
        private readonly string allCacheKey = "slider_all";
        private readonly CacheSettings _time;


        public SliderService(ISliderRepo command, IQueryRepo<Slider> query, IMapper mapper, IMemoryCache memory, IUnitOfWork save, IOptions<CacheSettings> time)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
            _memory = memory;
            _save = save;
            _time = time.Value;
        }

        public async Task<SliderVM> CreateAsync(CreateSliderVM dto)
        {
            var slider = _mapper.Map<Slider>(dto);
            var createSlider = await _command.CreateAsync(slider);
            await _save.SaveChangesAsync();
            var cacheKey = cacheKeyPrefix + createSlider.Id;
            _memory.Set(cacheKey, createSlider, TimeSpan.FromMinutes(_time.CacheMinutes));
            _memory.Remove(allCacheKey);
            return _mapper.Map<SliderVM>(createSlider);
        }

        public async Task<ICollection<SliderVM>> GetAllAsync()
        {
            if (_memory.TryGetValue(allCacheKey, out ICollection<Slider>? cachedDict))
            {
                return _mapper.Map<ICollection<SliderVM>>(cachedDict);
            }
            var allDatas = await _query.GetAllAsync().ToListAsync();
            _memory.Set(allCacheKey, allDatas, TimeSpan.FromMinutes(_time.CacheMinutes));
            return _mapper.Map<ICollection<SliderVM>>(allDatas);
        }

        public async Task<SliderVM> GetByIdAsync(Guid id)
        {
            var sliderId = await _query.GetByIdAsync(id);
            if (sliderId == null)
            {
                throw new NotFoundException($"Slider bu id:{id} ile tapilmadi");
            }
            return _mapper.Map<SliderVM>(sliderId);
        }

        public async Task RemoveAsync(Guid id)
        {
            var sliderId = await _query.GetByIdAsync(id);
            if (sliderId == null)
            {
                throw new NotFoundException($"Slider bu id:{id} ile tapilmadi");
            }
            await _command.DeleteAsync(sliderId);
            await _save.SaveChangesAsync();
            _memory.Remove(cacheKeyPrefix + sliderId);
            _memory.Remove(allCacheKey);
        }
    }
}
