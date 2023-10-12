using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Radicados : BaseEntities
    {
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
        public ICollection<ModuloNotificaciones> ModulosNotificaciones { get; set; }

    }
}