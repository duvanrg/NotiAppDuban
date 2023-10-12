using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class BlockChain : BaseEntity
    {
        [Required]
        public int IdNotificacion { get; set; }
        [Required]
        public int IdHiloRespuesta { get; set; }
        [Required]
        public int IdAuditoria { get; set; } 
        [Required]
        public string HashGenerado { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
        public TipoNotificacion TipoNotificacion { get; set; }
        public HiloRespuestaNotificacion HiloRespuestaNotificacion { get; set; }
        public Auditoria Auditoria { get; set; } 
    }
}