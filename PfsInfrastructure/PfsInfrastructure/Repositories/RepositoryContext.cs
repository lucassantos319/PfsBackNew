using Microsoft.EntityFrameworkCore;
using PfsDomain.Entities;
using PfsInfrastructure.Configurations;

namespace PfsInfrastructure.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        public DbSet<AccountRepo> Account { get; set; }
        public DbSet<AccountCreditCard> AccountCreditCard { get; set; }
        public DbSet<Banks> Banks { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Importance> Importances { get; set; }
        public DbSet<Painel> Painels { get; set; }
        public DbSet<PainelUsers> PainelUsers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigurationEntities();
        }
    }
}
