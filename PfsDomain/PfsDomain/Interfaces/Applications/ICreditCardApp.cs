using PfsDomain.Entities;
using PfsShared;
using PfsShared.ViewModels;

namespace PfsDomain.Interfaces.Applications
{
    public interface ICreditCardApp
    {
        Task<Result<CreditCard>> Create(CreditCardViewModel creditCard);
        Task<Result<IEnumerable<CreditCard>>> GetByPainelId(Guid painelId);
        Task<Result<CreditCard>> GetById(int id);
        Task<Result<bool>> DeleteById(int id);
        Task<Result<bool>> Update(CreditCardViewModel creditCard);
    }
}
