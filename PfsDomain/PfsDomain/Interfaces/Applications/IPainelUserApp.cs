using PfsDomain.Entities;
using PfsShared;
using PfsShared.ViewModels;

namespace PfsDomain.Interfaces.Applications
{
    public interface IPainelUserApp
    {
        Task<Result<PainelUsers>> Create(PainelRoleViewModel painelUser,int userId);
        Task<Result<bool>> Update(PainelUsers painelUser);
        Task<Result<IEnumerable<PainelUsers>>> GetByUserId(int userId);
        Task<Result<IEnumerable<PainelUsers>>> GetByPainelId(Guid painelId);
        Task<Result<bool>> ValidatePainelUser(User user);
        Task<Result<int>> GetUserIdByPainelId(Guid painelId);
    }
}
