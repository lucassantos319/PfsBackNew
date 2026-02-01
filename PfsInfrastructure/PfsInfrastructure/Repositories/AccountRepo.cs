using PfsDomain.Interfaces.Repositories;
using PfsInfrastructure.Repositories.Configuration;

namespace PfsInfrastructure.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private readonly RepositoryContext _context;
        public AccountRepo(RepositoryContext context) 
        {
            _context = context;
        }
    }
}
