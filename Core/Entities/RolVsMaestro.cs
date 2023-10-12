using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class RolVsMaestro : BaseEntities
    {
        [Required]
        public int IdRol { get; set; }
        [Required]
        public int IdMaestro { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
        public Rol Rol { get; set; }
        public ModulosMaestros ModulosMaestros { get; set; }
    }
}