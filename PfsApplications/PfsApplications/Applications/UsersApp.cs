using PfsDomain.Entities;
using PfsDomain.Interfaces.Applications;
using PfsDomain.Interfaces.Repositories;
using PfsInfrastructure.Configurations;
using PfsShared;
using PfsShared.Errors;
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
                return Error.Validacao(CodigosErros.USR_NOT_FOUND,MensagensErros.USR_NOT_FOUND);

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                return Error.Validacao(CodigosErros.USR_INVALID_PASSWORD,MensagensErros.USR_INVALID_PASSWORD);

            var token = TokenConfiguration.Generate(user);
            return Result.Sucesso;
        }
    }
}
