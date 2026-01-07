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

        public async Task<ResponseResult<Login.Response>> Login(Login.Request request)
        {
            var user = await _repository.GetLogin(request.Email, request.Password);
            if (user == null)
                return ResponseResult<Login.Response>.Error(new[] {new ErrorResult
                {
                    Code = "USR_NOT_FOUND",
                    Message = $"Usuario {request.Email} não encontrado."
                }});

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return ResponseResult<Login.Response>.Error(
                    new[] { new ErrorResult
                    {
                        Code = "USR_INVALID_PASSWORD",
                        Message = "Senha inválida."
                    }});
            }

            var token = TokenConfiguration.Generate(user);
            return new ResponseResult<Login.Response>
            {
                Obj = new[] { new Login.Response { AccessToken = token }},
                Success = true
            };
        }
    }
}
