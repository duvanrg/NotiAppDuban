using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Rol : BaseEntity
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
        public ICollection<GenericosVsSubmodulos> genericosVsSubmodulos { get; set; }
        public ICollection<RolVsMaestro> rolVsMaestros { get; set; }

    }
}