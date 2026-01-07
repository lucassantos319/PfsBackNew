using Microsoft.EntityFrameworkCore;
using PfsDomain.Entities;

namespace PfsInfrastructure.Configurations
{
    public static class RelationConfigurations
    {
        public static void ConfigurationEntities(this ModelBuilder model)
        {
            model.Entity<Account>()
                .HasOne(x => x.Bank)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.BankId)
                .HasPrincipalKey(x => x.Id);

            model.Entity<Account>()
                .HasOne(x => x.Painel)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.PainelId)
                .HasPrincipalKey(x => x.Id);

            model.Entity<Account>()
                .HasOne(x => x.User)
                .WithOne(x => x.Account)
                .HasForeignKey<Account>(x => x.UserCreatedId);

            model.Entity<AccountCreditCard>()
                .HasOne(x => x.Account)
                .WithMany(x => x.AccountCreditCards)
                .HasForeignKey(x => x.AccountId)
                .HasPrincipalKey(x => x.Id);
            
            model.Entity<AccountCreditCard>()
                .HasOne(x => x.CreditCard)
                .WithMany(x => x.AccountCreditCards)
                .HasForeignKey(x => x.CreditCardId)
                .HasPrincipalKey(x => x.Id);
           
            model.Entity<PainelUsers>()
                .HasOne(x => x.Painel)
                .WithMany(x => x.PainelUsers)
                .HasForeignKey(x => x.PainelId)
                .HasPrincipalKey(x => x.Id);

            model.Entity<PainelUsers>()
                .HasOne(x => x.User)
                .WithMany(x => x.PainelUsers)
                .HasForeignKey(x => x.UserId)
                .HasPrincipalKey(x => x.Id);

            model.Entity<Transaction>()
                .HasOne(x => x.Painel)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.PainelId)
                .HasPrincipalKey(x => x.Id);

            model.Entity<Transaction>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.CategoryId)
                .HasPrincipalKey(x => x.Id);

            model.Entity<Transaction>()
                .HasOne(x => x.Account)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.AccountId)
                .HasPrincipalKey(x => x.Id);

            model.Entity<Transaction>()
                .HasOne(x => x.User)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.UserId)
                .HasPrincipalKey(x => x.Id);

            model.Entity<User>();
            model.Entity<Banks>();
            model.Entity<Categories>();
            model.Entity<Importance>();
            model.Entity<Painel>();
        }
    }
}
