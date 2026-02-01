using Microsoft.EntityFrameworkCore;
using PfsDomain.Entities;
using PfsDomain.Interfaces.Repositories;
using PfsInfrastructure.Repositories.Configuration;
using PfsShared.Enums;

namespace PfsInfrastructure.Repositories
{
    public class UsersRepo : IUsersRepo
    {
        private readonly RepositoryContext _context;
        public UsersRepo(RepositoryContext context) 
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _context
                .Users
                .FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Status == EStatus.Ativo);

            return user;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _context
                .Users
                .FindAsync(id);

            if ( user == null || user?.Status != EStatus.Ativo )
                return null;

            return user;
        }

        public async Task<User> GetLogin(string email, string password)
        {
            var users = await _context.Users
                .FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Status == EStatus.Ativo);

            return users;
        }
    }
}
