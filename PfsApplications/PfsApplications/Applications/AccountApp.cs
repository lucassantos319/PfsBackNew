using AutoMapper;
using PfsDomain.Entities;
using PfsDomain.Interfaces.Applications;
using PfsDomain.Interfaces.Repositories;
using PfsShared;
using PfsShared.Enums;
using PfsShared.Errors;
using PfsShared.ViewModels;

namespace PfsApplications.Applications
{
    public class AccountApp : ApplicationBase<Account>, IAccountApp
    {
        readonly IAccountRepo _repository;
        readonly IPainelUserApp _painelUserApp;
        readonly IUsersApp _userApp;
        readonly IMapper _mapper;

        public AccountApp(IAccountRepo repository,
            IPainelUserApp painelUserApp,
            IUsersApp userApp,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _userApp = userApp;
            _painelUserApp = painelUserApp;
        }

        public async Task<Result<Account>> Create(AccountViewModel accountViewModel)
        {
            var account = _mapper.Map<Account>(accountViewModel);
            var validAccount = await Validate(account);  

            if ( validAccount.PossuiErro )
                return validAccount.Erro;

            var createdAccount = await _repository.Create(account);
            return createdAccount;
        }

        public Task<Result<IEnumerable<Account>>> GetByPainelId(Guid painelId)
        {
            throw new NotImplementedException();
        }

        protected override async Task<Result<Account>> Validate(Account account)
        {
            var userId = await _painelUserApp.GetUserIdByPainelId(account.PainelId);
            var user = await _userApp.GetUserById(userId.Valor);
            var accounts = await _repository.GetByPainelId(account.PainelId);

            var signatureValid = SignatureValidate(accounts.Count(),user.Valor.Signature);
            if ( !signatureValid )
                return Error.Validacao(CodigosErros.USER_SIGNATURE, MensagensErros.USER_SIGNATURE); 

            return account;
        }

        private static bool SignatureValidate(int accountCount, ESignature signature)
        {
            return signature switch
            {
                ESignature.FREE => accountCount <= 3 ? true : false,
                ESignature.PROFILE_1 => accountCount >= 3 && accountCount <= 10 ? true : false,
                ESignature.PROFILE_2 => true,
                _ => false
            };
        }
    }
}
