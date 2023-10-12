using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class TipoRequerimiento : BaseEntity
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }

        public ICollection<ModuloNotificaciones> ModulosNotificaciones { get; set; }
        
        
    }
}