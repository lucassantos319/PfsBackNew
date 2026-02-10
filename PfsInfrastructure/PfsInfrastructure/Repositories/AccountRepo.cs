using Microsoft.EntityFrameworkCore;
using PfsDomain.Entities;
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

        public async Task<Account> Create(Account account)
        {
            await _context.Account.AddAsync(account);
            await _context.SaveChangesAsync();

            return account;
        }

        public async Task<IEnumerable<Account>> GetByPainelId(Guid painelId)
        {
            var accounts = await _context
                .Account
                .Where(x => x.PainelId == painelId)
                .ToListAsync();

            return accounts;
        }

        public async Task<Account> GetById(int id)
        {
            var accounts = await _context
                .Account
                .FirstOrDefaultAsync(x => x.Id == id);

            return accounts;
        }

        public async Task Update(Account account)
        {
            _context.Account.Update(account);
            await _context.SaveChangesAsync();
        }

    }
}
