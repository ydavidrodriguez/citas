using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Citas.Infraestructure.Configuration
{
    public class EstadoConfiguration
    {
        public EstadoConfiguration(EntityTypeBuilder<Domain.Entities.Estado> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdEstado);
        }
    }
}
