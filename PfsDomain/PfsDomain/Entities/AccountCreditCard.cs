using PfsShared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PfsDomain.Entities
{
    [Table("AccountCreditCard", Schema = "Core")]
    public class AccountCreditCard : BaseEntity
    {
        public int AccountId { get; set; }
        public int CreditCardId { get; set; }   
        public EStatus Status { get; set; }
        public virtual Account Account { get; set; }
        public virtual CreditCard CreditCard { get; set; }
    }
}
