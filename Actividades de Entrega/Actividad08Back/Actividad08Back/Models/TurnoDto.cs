namespace Actividad08Back.Models
{
    public class TurnoDto
    {
        public DateOnly Fecha { get; set; }
        public TimeOnly Hora { get; set; }
        public Cliente Cliente { get; set; }
        public Servicio Servicio { get; set; }
    }
}
