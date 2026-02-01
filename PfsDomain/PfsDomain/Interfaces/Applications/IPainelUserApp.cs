using PfsDomain.Entities;
using PfsShared;

namespace PfsDomain.Interfaces.Applications
{
    public interface IPainelUserApp
    {
        Task<Result<PainelUsers>> Create(PainelUsers painelUser);
        Task<Result<bool>> Update(PainelUsers painelUser);
        Task<Result<IEnumerable<PainelUsers>>> GetByUserId(int userId);
        Task<Result<IEnumerable<PainelUsers>>> GetByPainelId(int painelId);
        Task<Result<User>> ValidatePainelUser(User user);
    }
}
