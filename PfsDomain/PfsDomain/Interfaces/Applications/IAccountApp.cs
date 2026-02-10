using PfsDomain.Entities;
using PfsShared;
using PfsShared.ViewModels;

namespace PfsDomain.Interfaces.Applications
{
    public interface IAccountApp
    {
        Task<Result<Account>> Create(AccountViewModel account);
        Task<Result<IEnumerable<Account>>> GetByPainelId(Guid painelId);
        Task<Result<Account>> GetById(int id);
        Task<Result<bool>> DeleteById(int id);
        Task<Result<bool>> Update(AccountViewModel account);
    }
}
