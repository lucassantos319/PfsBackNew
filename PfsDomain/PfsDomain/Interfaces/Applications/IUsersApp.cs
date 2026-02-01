using PfsDomain.Entities;
using PfsShared;
using PfsShared.ViewModels;

namespace PfsDomain.Interfaces.Applications
{
    public interface IUsersApp
    {
        Task<Result<LoginViewModel.Response>> Login(LoginViewModel.Request request);
        Task<Result<User>> GetUserById(int id);
        Task<Result<User>> Create(UserViewModel.Create.Request request); 
        
    }
}
