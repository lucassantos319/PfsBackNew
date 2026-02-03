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
            Signature = ESignature.FREE;
            CreateAt = DateTime.UtcNow;
            UpdateAt = DateTime.UtcNow;
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
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get;set; }
        public string? Password { get; set; }
        public EStatus Status { get; set; }
        public string? GoogleId { get; set; }
        public string? PictureUrl { get; set; }
        public virtual Account Account { get; set; }
        public virtual IEnumerable<PainelUsers> PainelUsers { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; }
        public ESignature Signature { get; set; }
    }
}
