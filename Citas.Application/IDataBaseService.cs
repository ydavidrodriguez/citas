using Microsoft.EntityFrameworkCore;

namespace Citas.Application
{
    public interface IDataBaseService
    {
        public DbSet<Domain.Entities.Citas> Citas { get; set; }
        public DbSet<Domain.Entities.Estado> Estado { get; set; }
        Task<bool> SaveAsync();
    }
}
