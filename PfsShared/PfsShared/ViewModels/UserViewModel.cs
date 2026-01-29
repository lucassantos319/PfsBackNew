using PfsShared.Enums;
using System.Transactions;

namespace PfsShared.ViewModels
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public EStatus Status { get; set; }
        public AccountViewModel Account { get; set; }
        //public virtual IEnumerable<PainelUsers> PainelUsers { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; }
    }
}
