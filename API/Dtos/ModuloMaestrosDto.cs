namespace API.Dtos
{
    public class ModuloMaestrosDto
    {
        public int Id { get; set; }
        public string AsuntoNotificacion { get; set; }
        public int IdTipoNotificacion { get; set; }
        public int IdRadicado { get; set; }
        public int IdEstadoNotificacion { get; set; }
        public int IdHiloNotificacion { get; set; }
        public int IdFormato { get; set; }
        public int IdRequerimiento { get; set; }
        public string TextoNotificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}