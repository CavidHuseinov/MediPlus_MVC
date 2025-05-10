
using FluentValidation;
using MediPlus.Application.ViewModels.Slider;

namespace MediPlus.Application.Validators.Slider
{
    public class CreateSliderValidator : AbstractValidator<CreateSliderVM>
    {
        public CreateSliderValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
