

using PfsDomain.Entities;
using PfsShared;
using PfsShared.ViewModels;

namespace PfsDomain.Interfaces.Applications
{
    public interface ITransactionApp
    {
        Task<Result<Transaction>> Create(TransactionViewModel transaction);
        Task<Result<IEnumerable<Transaction>>> GetByPainelId(Guid painelId);
        Task<Result<Transaction>> GetById(int id);
        Task<Result<bool>> DeleteById(int id);
        Task<Result<bool>> Update(TransactionViewModel transaction);
    }
}
