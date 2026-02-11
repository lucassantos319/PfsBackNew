using PfsDomain.Entities;
using PfsShared;
using PfsShared.ViewModels;

namespace PfsDomain.Interfaces.Applications
{
    public interface IPainelApp 
    {
        Task<Result<Painel>> Create(PainelViewModel painel);
        Task<Result<Painel>> GetById(int id);
        Task<Result<bool>> DeleteById(int id);
        Task<Result<bool>> Update(PainelViewModel creditCard);
        Task<Result<IEnumerable<Painel>>> GetByUserId(int userId);
    }
}
