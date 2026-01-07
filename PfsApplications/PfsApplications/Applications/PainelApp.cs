using PfsDomain.Interfaces.Applications;
using PfsDomain.Interfaces.Repositories;

namespace PfsApplications.Applications
{
    public class PainelApp : IPainelApp
    {
        private readonly IPainelRepo _repository;

        public PainelApp(IPainelRepo repository )
        {
            _repository = repository;
        }


    }
}
