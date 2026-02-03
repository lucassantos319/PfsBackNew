using PfsDomain.Entities;
using PfsShared;
using PfsShared.ViewModels;

namespace PfsDomain.Interfaces.Applications
{
    public interface IPainelApp 
    {
        Task<Result<Painel>> Create(PainelViewModel painel);
    }
}
