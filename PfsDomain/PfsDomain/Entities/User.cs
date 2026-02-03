using BCrypt.Net;
using PfsShared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PfsDomain.Entities
{
    [Table("Users", Schema = "Management")]
    public class User : BaseEntity
    {
        public void NewValidUser()
        {
            Password = BCrypt.Net.BCrypt.HashPassword(Password);
            Status = EStatus.Ativo;
        }

        public bool SignatureValid(int painelUserCount)
        {
            return Signature switch
            {
                ESignature.FREE => painelUserCount <= 3 ? true : false,
                ESignature.PROFILE_1 => painelUserCount >= 3 && painelUserCount <= 10 ? true : false,
                ESignature.PROFILE_2 => true,
                _ => false  
            };
        }

        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get;set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public EStatus Status { get; set; }
        public string GoogleId { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty;
        public virtual Account Account { get; set; }
        public virtual IEnumerable<PainelUsers> PainelUsers { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; }
        public ESignature Signature { get; set; }
    }
}
