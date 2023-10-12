using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Rol : BaseEntities
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
    }
}