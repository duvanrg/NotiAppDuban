namespace API.Dtos
{
    public class MaestrosVsSubmodulosDto
    {
        public int Id { get; set; }
        public int IdMaestro { get; set; }
        public int IdSubmodulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}