using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class GenericosVsSubmodulos : BaseEntities
    {
        [Required]
        public int IdGenericos { get; set; }
        [Required]
        public int IdSubmodulos { get; set; }
        [Required]
        public int IdRol { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
        public PermisosGenericos Name { get; set; }        
        public Submodulos Submodulos{ get; set; }
        public Rol rol { get; set; }
    }
}