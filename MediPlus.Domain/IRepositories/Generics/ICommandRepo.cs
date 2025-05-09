using MediPlus.Core.Abstractions;

namespace MediPlus.Domain.IRepositories.Generics
{
    public interface ICommandRepo<TEntity> where TEntity : BaseEntity, new()
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
