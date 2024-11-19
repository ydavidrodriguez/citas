using Citas.Domain.Entities;

namespace Citas.Domain.Dto
{
    public class PutUpdateCitasRequest
    {
        public Guid IdCita { get; set; }
        public DateTime FechaCita { get; set; }
        public string Lugar { get; set; }
        public Guid IdPaciente { get; set; }
        public Guid IdMedico { get; set; }
        public Guid EstadoId { get; set; }

    }
}
