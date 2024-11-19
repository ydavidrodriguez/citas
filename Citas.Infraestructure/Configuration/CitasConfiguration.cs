using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Citas.Infraestructure.Configuration
{
    public class CitasConfiguration
    {
        public CitasConfiguration(EntityTypeBuilder<Domain.Entities.Citas> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdCita);
        }

    }
}
