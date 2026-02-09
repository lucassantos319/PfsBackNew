using PfsDomain.Entities;
using PfsShared;
using PfsShared.ViewModels;

namespace PfsDomain.Interfaces.Applications
{
    public interface IAccountApp
    {
        Task<Result<Account>> Create(AccountViewModel account);
        Task<Result<IEnumerable<Account>>> GetByPainelId(Guid painelId);
    }
}
