using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class GenericosVsSubmodulos : BaseEntity
    {
        [Required]
        public int IdGenericos { get; set; }
        [Required]
        public int IdMaestrosSubmodulos { get; set; }
        [Required]
        public int IdRol { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
        public PermisosGenericos PermisosGenericos { get; set; }        
        public MaestrosVsSubmodulos MaestrosVsSubmodulos { get; set; }
        public Rol rol { get; set; }
    }
}