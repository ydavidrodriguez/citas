namespace Citas.Domain.Dto
{
    public class PostCreateCitasRequest
    {
        public DateTime FechaCita { get; set; }
        public string Lugar { get; set; }
        public Guid IdPaciente { get; set; }
        public Guid IdMedico { get; set; }
        public Guid EstadoId { get; set; }

    }
}
