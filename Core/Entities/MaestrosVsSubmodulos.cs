using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class MaestrosVsSubmodulos : BaseEntity
    {
        [Required]
        public int IdMaestro { get; set; }
        [Required]
        public int IdSubmodulo { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
        public Submodulos Submodulos { get; set; }
        public ModuloMaestros ModulosMaestros { get; set; }
        public ICollection<GenericosVsSubmodulos> GenericosVsSubmodulos { get; set; }
        
        
    }
}