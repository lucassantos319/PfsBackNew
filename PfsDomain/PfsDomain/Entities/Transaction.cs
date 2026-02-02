using PfsShared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PfsDomain.Entities
{
    [Table("Transactions", Schema = "Core")]
    public class Transaction : BaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public int CategoryId { get; set; }
        public Guid PainelId { get; set; }
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public EStatus Status { get; set; }
        public virtual Categories Category { get; set; }
        public virtual Painel Painel { get; set; }
        public virtual User User { get; set; }
        public virtual Account Account { get; set; }
    }
}
