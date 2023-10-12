using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class HiloRespuestaNotificacion : BaseEntity
    {
        [Required]
        public string NombreTipo { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
        public ICollection<ModuloNotificaciones> ModulosNotificaciones { get; set; }
        public ICollection<BlockChain> BlockChains { get; set; }


    }
}