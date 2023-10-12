using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class PermisosGenericos : BaseEntities
    {
        [Required]
        public string NombrePermiso { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
    }
}