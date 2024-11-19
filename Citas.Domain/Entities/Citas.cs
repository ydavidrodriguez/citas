namespace Citas.Domain.Entities
{
    public class Citas
    {
        public Guid IdCita { get; set; }
        public DateTime FechaCita { get; set; }
        public string Lugar { get; set; }
        public Guid IdPaciente { get; set; }
        public Guid IdMedico { get; set; }
        public Estado Estado { get; set; }
        public Guid EstadoId { get; set; }


    }
}
