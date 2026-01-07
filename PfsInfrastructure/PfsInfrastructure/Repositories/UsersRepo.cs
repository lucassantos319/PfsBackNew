using Microsoft.EntityFrameworkCore;
using PfsDomain.Entities;
using PfsDomain.Interfaces.Repositories;

namespace PfsInfrastructure.Repositories
{
    public class UsersRepo : IUsersRepo
    {
        private readonly RepositoryContext _context;
        public UsersRepo(RepositoryContext context) 
        {
            _context = context;
        }

        public async Task<User> GetLogin(string email, string password)
        {
            var users = await _context.Users
                .FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Status == PfsDomain.Enums.EStatus.Ativo);

            return users;
        }
    }
}
