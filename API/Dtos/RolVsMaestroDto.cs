namespace API.Dtos
{
    public class RolVsMaestroDto
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdMaestro { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}