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

        protected override async Task<Result<Painel>> Validate(Painel newPainel)
        {
            throw new NotImplementedException();
        }
    }
}
