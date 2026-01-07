using PfsDomain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PfsDomain.Entities
{

    [Table("Banks", Schema = "Management")]
    public class Banks : BaseEntity
    {
        public string Name { get; set; }
        public EStatus Status { get; set; }
        public virtual List<Account> Accounts { get; set; }
    }
}
