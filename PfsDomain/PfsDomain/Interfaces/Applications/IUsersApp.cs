using PfsShared;
using PfsShared.ViewModels;

namespace PfsDomain.Interfaces.Applications
{
    public interface IUsersApp
    {
        Task<ResponseResult<Login.Response>> Login(Login.Request request);
    }
}
