
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PfsInfrastructure.Repositories
{
    public class RepositoryContextFactory
        : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();

            optionsBuilder.UseNpgsql(
                "host=localhost;port=5432;user=pfadmin;dbname=pfsdb;password=StrongPassword12");

            return new RepositoryContext(optionsBuilder.Options);
        }
    }
}
