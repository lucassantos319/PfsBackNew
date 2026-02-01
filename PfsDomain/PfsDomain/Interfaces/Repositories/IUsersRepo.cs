using PfsDomain.Entities;

namespace PfsDomain.Interfaces.Repositories
{
    public interface IUsersRepo
    {
        Task<User> GetLogin(string email, string password);
        Task<User> GetById(int id);
        Task<User> GetByEmail(string email);
        Task<User> Create(User user);
    }
}
