
using PfsDomain.Entities;

namespace PfsDomain.Interfaces.Repositories
{
    public interface IPainelUserRepo
    {
        Task<PainelUsers> Create(PainelUsers painelUser);
        Task<bool> Update(PainelUsers painelUser);
        Task<IEnumerable<PainelUsers>> GetByUserId(int userId);
        Task<IEnumerable<PainelUsers>> GetByPainelId(Guid painelId);
    }
}
