using Citas.Domain.Services.Interfaces.Citas;
using Citas.Infraestructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Citas.Infraestructure.Repositories.Citas
{
    public class CitaRepository : EntityRepository<Domain.Entities.Citas>, ICitaRepository
    {
        private readonly DataBaseService _context;
        public CitaRepository(DataBaseService context) : base(context)
        {
            this._context = context;
        }

        public  Domain.Entities.Citas GetByExistCitas(Guid idPersona, Guid idMedico) 
        {
            return _context.Citas.Where(x => x.IdMedico == idMedico && x.IdPaciente == idPersona).FirstOrDefault();
        }

        public Domain.Entities.Citas GetByIdCitas(Guid Id) 
        {
            return _context.Citas
                .Include(x=> x.Estado)
                .Where(x => x.IdCita == Id).FirstOrDefault();
            
        }



    }
}
