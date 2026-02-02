using PfsDomain.Entities;
using PfsDomain.Interfaces.Applications;
using PfsDomain.Interfaces.Repositories;
using PfsShared;
using PfsShared.Errors;

namespace PfsApplications.Applications
{
    public class PainelUserApp : IPainelUserApp
    {
        readonly IPainelUserRepo _repository;
        public PainelUserApp(IPainelUserRepo repository)
        {
            _repository = repository;
        }

        public async Task<Result<PainelUsers>> Create(User user)
        {
            var painelUser = user.PainelUsers.FirstOrDefault();
            if (painelUser == null)
                return Error.Validacao(CodigosErros.PAINEL_USER_INVALID, MensagensErros.PAINEL_USER_INVALID);

            painelUser.UserId = user.Id;
            var createdPainelUser = await _repository.Create(painelUser);
            return createdPainelUser;
        }

        public Task<Result<IEnumerable<PainelUsers>>> GetByPainelId(int painelId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<PainelUsers>>> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> Update(PainelUsers painelUser)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<bool>> ValidatePainelUser(User user)
        {
            Result<PainelUsers> createdPainelUser = default(Result<PainelUsers>);
            
            var existedUserPainel = await _repository.GetByUserId(user.Id);
            if (existedUserPainel != null && existedUserPainel.Count() > 0)
            {
                var userSignatureValid = user.SignatureValid(existedUserPainel.Count());
                if (userSignatureValid)
                {
                    var painelUser = user.PainelUsers.FirstOrDefault();
                    if (painelUser == null)
                        return Error.Validacao(CodigosErros.PAINEL_USER_INVALID, MensagensErros.PAINEL_USER_INVALID);

                    return true;
                }
                else
                    return Error.Validacao(CodigosErros.USER_SIGNATURE,MensagensErros.USER_SIGNATURE);

            }

            return true;
        }
    }
}
