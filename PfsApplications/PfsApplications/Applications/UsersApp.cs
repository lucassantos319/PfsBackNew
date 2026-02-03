using AutoMapper;
using PfsDomain.Entities;
using PfsDomain.Interfaces.Applications;
using PfsDomain.Interfaces.Repositories;
using PfsInfrastructure.Configurations;
using PfsShared;
using PfsShared.Errors;
using PfsShared.ViewModels;

namespace PfsApplications.Applications
{
    public class UsersApp : ApplicationBase<User> ,IUsersApp
    {
        readonly IMapper _mapper;
        readonly IUsersRepo _repository;
        readonly IPainelUserApp _painelUsersApp;

        public UsersApp(IMapper mapper, 
            IUsersRepo repository,
            IPainelUserApp painelUserApp)
        {
            _mapper = mapper;
            _repository = repository;
            _painelUsersApp = painelUserApp;
        }

        public async Task<Result<User>> Create(UserViewModel.Create.UserRequest request)
        {
            try
            {
                var newUser = _mapper.Map<User>(request);
                var validUser = await Validate(newUser);

                if (validUser.PossuiErro)
                    return validUser.Erro;

                var user = await _repository.Create(validUser.Valor);
                var painelUser = await _painelUsersApp.Create(request.PainelRole,user.Id);

                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected override async Task<Result<User>> Validate(User newUser)
        {
            var existingUser = await _repository.GetByEmail(newUser.Email);
            if (existingUser != null)
                return Error.Validacao(CodigosErros.USR_ALREADY_EXIST,MensagensErros.USR_ALREADY_EXIST);

            newUser.NewValidUser(); 
            return newUser;
        }

        public async Task<Result<User>> GetUserById(int id)
        {
            var user = await _repository.GetById(id);
            if ( user == null)
                return Error.Validacao(CodigosErros.USR_NOT_FOUND,MensagensErros.USR_NOT_FOUND);

            return user;
        }

        public async Task<Result<LoginViewModel.LoginResponse>> Login(LoginViewModel.LoginRequest request)
        {
            var user = await _repository.GetByEmail(request.Email);
            if (user == null)
                return Error.Validacao(CodigosErros.USR_NOT_FOUND,MensagensErros.USR_NOT_FOUND);

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                return Error.Validacao(CodigosErros.USR_INVALID_PASSWORD,MensagensErros.USR_INVALID_PASSWORD);

            var token = TokenConfiguration.Generate(user);
            return new LoginViewModel.LoginResponse { AccessToken = token };
        }

        public Task<Result> Update(UserViewModel request)
        {
            throw new NotImplementedException();
        }
    }
}
