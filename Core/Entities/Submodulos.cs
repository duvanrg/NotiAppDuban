using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Submodulos : BaseEntity
    {
        [Required]
        public string NombreSubmodulo { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
        public ICollection<MaestrosVsSubmodulos> MaestrosVsSubmodulos { get; set; }

    }
}