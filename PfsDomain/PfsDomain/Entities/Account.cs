using PfsShared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PfsDomain.Entities
{
    [Table("Accounts",Schema = "Management")]
    public class Account : BaseEntity
    {
        public int BankId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Password { get; set; }
        public double CurrentAmount { get; set; }
        public int PainelId { get; set; }
        public int UserCreatedId { get; set; }
        public virtual User User { get; set; }
        public virtual Painel Painel { get; set; }
        public virtual Banks Bank { get; set; }
        public virtual IEnumerable<AccountCreditCard> AccountCreditCards { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; }
        public EStatus Status { get; set; }
    }
}
