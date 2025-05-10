using MediPlus.Application.ViewModels.Slider;
using MediPlus.Core.Abstractions;
using MediPlus.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediPlus.UI.Areas.Admin.Controllers
{
    public sealed class SliderController : BaseController
    {
        private readonly ISliderService _service;
        private readonly ILogger<SliderController> _logger;

        public SliderController(ISliderService service, ILogger<SliderController> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var all = await _service.GetAllAsync();
            return View(all);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderVM vm)
        {
            try
            {
                var create = await _service.CreateAsync(vm);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Blog yaratmaq mumkun olmadi.Blogun basligi: {vm.Title}");
                throw new Exception($"Blog yaratmaq mumkun olmadi, xeta:{ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _service.RemoveAsync(id);
            return RedirectToAction("Index");
        }
    }

}
