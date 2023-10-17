namespace API.Dtos
{
    public class EstadoNotificacionDto
    {
        public int Id { get; set; }
        public string NombreEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}