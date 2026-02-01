
using Microsoft.EntityFrameworkCore;
using PfsDomain.Entities;
using PfsDomain.Interfaces.Repositories;
using PfsInfrastructure.Repositories.Configuration;

namespace PfsInfrastructure.Repositories
{
    public class PainelUserRepo : IPainelUserRepo
    {
        readonly RepositoryContext _context;
        public PainelUserRepo(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<PainelUsers> Create(PainelUsers painelUser)
        {
            await _context.PainelUsers.AddAsync(painelUser);
            await _context.SaveChangesAsync();

            return painelUser;
        }

        public async Task<IEnumerable<PainelUsers>> GetByPainelId(Guid painelId)
        {
            var painelUsers = await _context.PainelUsers
                .Where(x => x.PainelId == painelId)
                .ToListAsync();

            return painelUsers;
        }

        public async Task<IEnumerable<PainelUsers>> GetByUserId(int userId)
        {
            var painelUsers = await _context.PainelUsers
               .Where(x => x.UserId == userId)
               .ToListAsync();

            return painelUsers;
        }

        public async Task<bool> Update(PainelUsers painelUser)
        {
            _context.PainelUsers.Update(painelUser);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
