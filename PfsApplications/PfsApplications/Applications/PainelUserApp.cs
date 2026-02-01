using PfsDomain.Entities;
using PfsDomain.Interfaces.Applications;
using PfsDomain.Interfaces.Repositories;
using PfsShared;

namespace PfsApplications.Applications
{
    public class PainelUserApp : IPainelUserApp
    {
        readonly IPainelUserRepo _repository;
        public PainelUserApp(IPainelUserRepo repository)
        {
            _repository = repository;
        }

        public Task<Result<PainelUsers>> Create(PainelUsers painelUser)
        {
            throw new NotImplementedException();
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

        public async Task<Result<User>> ValidatePainelUser(User user)
        {
            var existedUserPainel = await _repository.GetByUserId(user.Id);


        }
    }
}
