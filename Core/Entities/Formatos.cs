using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Formatos : BaseEntity
    {
        [Required]
        public string NombreFormato { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
        public ICollection<ModuloNotificaciones> ModulosNotificaciones { get; set; }

    }
}