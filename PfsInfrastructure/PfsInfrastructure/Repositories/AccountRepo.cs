using PfsDomain.Interfaces.Repositories;

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
