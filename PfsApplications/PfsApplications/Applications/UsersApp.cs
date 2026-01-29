using PfsDomain.Entities;
using PfsDomain.Interfaces.Applications;
using PfsDomain.Interfaces.Repositories;
using PfsInfrastructure.Configurations;
using PfsShared;
using PfsShared.ViewModels;

namespace PfsApplications.Applications
{
    public class UsersApp : IUsersApp
    {
        private readonly IUsersRepo _repository;
        public UsersApp(IUsersRepo repository)
        {
            _repository = repository;
        }

        public async Task<Result<User>> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<LoginViewModel.Response>> Login(LoginViewModel.Request request)
        {
            var user = await _repository.GetLogin(request.Email, request.Password);
            if (user == null)
                return Result<LoginViewModel.Response>.Error();

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                return Result<LoginViewModel.Response>.Error("USR_INVALID_PASSWORD", "Senha inválida.");

            var token = TokenConfiguration.Generate(user);
            return new Result<LoginViewModel.Response>
            {
                Obj = new[] { new LoginViewModel.Response { AccessToken = token }},
                Success = true
            };
        }
    }
}
