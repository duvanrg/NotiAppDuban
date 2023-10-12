using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class ModulosMaestros : BaseEntities
    {
        [Required]
        public string NombreModulo { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
    }
}