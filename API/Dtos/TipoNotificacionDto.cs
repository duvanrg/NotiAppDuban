namespace API.Dtos
{
    public class TipoNotificacionDto
    {
        public int Id { get; set; }
        public string NombreTipo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}