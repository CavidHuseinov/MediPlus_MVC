
using MediPlus.Domain.Entities;
using MediPlus.Domain.IRepositories;
using MediPlus.Persistance.Context;
using MediPlus.Persistance.Repositories.Generics;

namespace MediPlus.Persistance.Repositories
{
    public class SliderRepo : CommandRepo<Slider>, ISliderRepo
    {
        public SliderRepo(MediPlusDb context) : base(context)
        {
        }
    }
}
