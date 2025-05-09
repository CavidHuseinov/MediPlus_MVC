
using MediPlus.Core.Abstractions;
using MediPlus.Domain.IRepositories.Generics;
using MediPlus.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace MediPlus.Persistance.Repositories.Generics
{
    public class CommandRepo<TEntity> : ICommandRepo<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly MediPlusDb _context;


        public CommandRepo(MediPlusDb context)
        {
            _context = context;
        }
        private DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Table.Remove(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var existingEntity = await Table.FindAsync(entity.Id);
            if (existingEntity == null)
            {
                throw new Exception($"{entity} not found");
            }
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);

        }
    }
}