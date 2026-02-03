
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PfsInfrastructure.Repositories.Configuration
{
    public class RepositoryContextFactory
        : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();

            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Username=pfs;Database=pfs;Password=admin");

            return new RepositoryContext(optionsBuilder.Options);
        }
    }
}
