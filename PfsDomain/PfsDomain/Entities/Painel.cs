using PfsDomain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PfsDomain.Entities
{
    [Table("Painels", Schema = "Management")]
    public class Painel : BaseEntity
    {
        public string Name { get; set; }
        public double CurrentAmount { get; set; }
        public double CurrentDebitAmount { get; set; }
        public double CurrentIncomeAmount { get; set; }
        public ERole Role { get; set; }
        public string DbConnectionString { get; set; }
        public EStatus Status { get; set; }
        public double PercentualMonthComparation { get; set; }
        public virtual IEnumerable<Account> Accounts { get; set; } 
        public virtual IEnumerable<PainelUsers> PainelUsers { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; }  
    }
}
