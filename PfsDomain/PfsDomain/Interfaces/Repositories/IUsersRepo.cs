using PfsDomain.Entities;

namespace PfsDomain.Interfaces.Repositories
{
    public interface IUsersRepo
    {
        Task<User> GetLogin(string email, string password);
        //Task<>
    }
}
