namespace API.Dtos
{
    public class AuditoriaDto
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public int DescAccion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}