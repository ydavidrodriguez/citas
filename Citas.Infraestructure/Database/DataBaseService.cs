using Citas.Application;
using Citas.Infraestructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Citas.Infraestructure.Database
{
    public class DataBaseService : DbContext, IDataBaseService
    {
        public DataBaseService(DbContextOptions<DataBaseService> options) : base(options)
        {


        }

        public DbSet<Domain.Entities.Citas> Citas { get; set; }
        public DbSet<Domain.Entities.Estado> Estado { get; set; }
        

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfuguration(modelBuilder);
        }
        private void EntityConfuguration(ModelBuilder modelBuilder)
        {
            new CitasConfiguration(modelBuilder.Entity<Domain.Entities.Citas>());
            new EstadoConfiguration(modelBuilder.Entity<Domain.Entities.Estado>());
         
        }


    }
}
