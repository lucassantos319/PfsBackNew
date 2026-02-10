using PfsDomain.Entities;

namespace PfsDomain.Interfaces.Repositories
{
    public interface IAccountRepo
    {
        Task<IEnumerable<Account>> GetByPainelId(Guid painelId);
        Task<Account> GetById(int id);
        Task<Account> Create(Account account);
        Task Update(Account account);
    }
}
