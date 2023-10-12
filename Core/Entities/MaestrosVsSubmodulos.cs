using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class MaestrosVsSubmodulos : BaseEntities
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
        public ModulosMaestros ModulosMaestros { get; set; }
    }
}