using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Auditoria : BaseEntity
    {
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public int DescAccion { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
        public ICollection<BlockChain> BlockChains { get; set; }
    }
}