
using MediPlus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MediPlus.Persistance.Context
{
    public class MediPlusDb : DbContext
    {
        public MediPlusDb(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Slider> Sliders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
