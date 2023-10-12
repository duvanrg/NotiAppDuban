using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class ModuloNotificaciones : BaseEntities
    {
        [Required]
        public string AsuntoNotificacion { get; set; }
        [Required]
        public int IdTipoNotificacion { get; set; }
        [Required]
        public int IdRadicado { get; set; }
        [Required]
        public int IdEstadoNotificacion { get; set; }
        [Required]
        public int IdHiloNotificacion { get; set; }
        [Required]
        public int IdFormato { get; set; }
        [Required]
        public int IdRequerimiento { get; set; }
        [Required]
        public string TextoNotificacion { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
        public TipoNotificacion TipoNotificacion { get; set; }
        public Radicados Radicados { get; set; }
        public EstadoNotificacion EstadoNotificacion { get; set; }
        public HiloRespuestaNotificacion HiloRespuestaNotificacion { get; set; }
        public Formatos Formatos { get; set; }
        public TipoRequerimiento TipoRequerimiento { get; set; }
    }
}