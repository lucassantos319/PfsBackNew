using AutoMapper;
using PfsDomain.Entities;
using PfsDomain.Interfaces.Applications;
using PfsDomain.Interfaces.Repositories;
using PfsShared;
using PfsShared.ViewModels;

namespace PfsApplications.Applications
{
    public class PainelApp : ApplicationBase<Painel>, IPainelApp
    {
        readonly IPainelRepo _repository;
        readonly IMapper _mapper;

        public PainelApp(IPainelRepo repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<Painel>> Create(PainelViewModel painel)
        {
            var newPainel = _mapper.Map<Painel>(painel);
            var validPainel = await Validate(newPainel);
            
            
            return null;
        }

        public Task<Result<bool>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Painel>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> Update(PainelViewModel creditCard)
        {
            throw new NotImplementedException();
        }

        protected override async Task<Result<Painel>> Validate(Painel newPainel)
        {
            throw new NotImplementedException();
        }

        Task<Result<IEnumerable<Painel>>> IPainelApp.GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
