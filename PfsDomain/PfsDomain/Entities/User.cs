using PfsShared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PfsDomain.Entities
{
    [Table("Users", Schema = "Management")]
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get;set; }
        public string Password { get; set; }
        public EStatus Status { get; set; }
        public virtual Account Account { get; set; }
        public virtual IEnumerable<PainelUsers> PainelUsers { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; }
    }
}
