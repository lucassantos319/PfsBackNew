using PfsDomain.Entities;
using PfsShared;
using PfsShared.ViewModels;

namespace PfsDomain.Interfaces.Applications
{
    public interface ICategoriesApp
    {
        Task<Result<Categories>> Create(CategoriesViewModel categories);
        Task<Result<IEnumerable<Categories>>> GetByPainelId(Guid painelId);
        Task<Result<Categories>> GetById(int id);
        Task<Result<bool>> DeleteById(int id);
        Task<Result<bool>> Update(CategoriesViewModel categories);

    }
}
