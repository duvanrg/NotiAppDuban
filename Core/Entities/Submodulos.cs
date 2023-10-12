using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Submodulos : BaseEntities
    {
        [Required]
        public string NombreSubmodulo { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
    }
}