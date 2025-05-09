
using FluentValidation;
using MediPlus.Application.DTOs.Slider;

namespace MediPlus.Application.Validators.Slider
{
    public class CreateSliderValidator : AbstractValidator<CreateSliderDto>
    {
        public CreateSliderValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
