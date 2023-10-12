using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class PermisosGenericos : BaseEntity
    {
        [Required]
        public string NombrePermiso { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }

        public ICollection<GenericosVsSubmodulos> genericosVsSubmodulos { get; set; }
        
        
    }
}