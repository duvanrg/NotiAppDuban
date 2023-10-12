using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class ModulosMaestros : BaseEntity
    {
        [Required]
        public string NombreModulo { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
        public ICollection<MaestrosVsSubmodulos> MaestrosVsSubmodulos { get; set; }
        public ICollection<RolVsMaestro> rolVsMaestros { get; set; }

    }
}