using PfsDomain.Entities;
using PfsShared;
using PfsShared.ViewModels;

namespace PfsDomain.Interfaces.Applications
{
    public interface IUsersApp 
    {
        Task<Result<LoginViewModel.LoginResponse>> Login(LoginViewModel.LoginRequest request);
        Task<Result<User>> GetById(int id);
        Task<Result<User>> Create(UserViewModel.Create.UserRequest request); 
        Task<Result> Update(UserViewModel request);
        Task<Result> DeleteById(int id);
    }
}
