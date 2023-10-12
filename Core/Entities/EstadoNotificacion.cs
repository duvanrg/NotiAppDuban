using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class EstadoNotificacion : BaseEntity
    {
        [Required]
        public string NombreEstado { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
        public ICollection<ModuloNotificaciones> ModulosNotificaciones { get; set; }

    }
}