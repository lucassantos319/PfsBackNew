using PfsShared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PfsDomain.Entities
{
    [Table("CreditCards", Schema = "Core")]
    public class CreditCard : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreditCardNumber { get; set; }
        public string SafetyNumber { get; set; }
        public DateTime ValidDate { get; set; }
        public EStatus Status { get; set; }
        public virtual IEnumerable<AccountCreditCard> AccountCreditCards { get; set; }
    }
}
