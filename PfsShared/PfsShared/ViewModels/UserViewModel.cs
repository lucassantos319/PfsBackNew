using PfsShared.Enums;
using System.Transactions;

namespace PfsShared.ViewModels
{
    public class UserViewModel : UserBaseViewModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public EStatus Status { get; set; }
        public AccountViewModel Account { get; set; }
        //public virtual IEnumerable<PainelUsers> PainelUsers { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; }
 
        public class Create
        {
            public class Request : UserBaseViewModel
            { 
                public string GoogleId { get; set; }
                public string PictureUrl { get; set; }
                public PainelUserViewModel PainelRole { get; set; }
            }
        }
    }

    public class UserBaseViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }    
    }

    public class PainelUserViewModel
    {
        public int PainelId { get; set; }
        public ERole Role { get; set; }
    }
}
