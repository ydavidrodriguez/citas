using Citas.Domain.Services.Interfaces.IRepository;

namespace Citas.Domain.Services.Interfaces.Citas
{
    public interface ICitaRepository : IRepository<Entities.Citas>
    {
        Entities.Citas GetByExistCitas(Guid idPersona, Guid idMedico);

        Entities.Citas GetByIdCitas(Guid Id);


    }
}
