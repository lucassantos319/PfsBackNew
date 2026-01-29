using PfsShared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PfsDomain.Entities
{
    [Table("PainelUsers", Schema = "Management")]
    public class PainelUsers : BaseEntity
    {
        public int PainelId { get; set; }
        public int UserId { get; set; }
        public ERole Role { get; set; }
        public EStatus Status { get; set; }
        public virtual Painel Painel { get; set; }
        public virtual User User { get; set; }
    }
}
