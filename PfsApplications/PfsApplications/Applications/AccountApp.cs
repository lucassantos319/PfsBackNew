using PfsDomain.Interfaces.Applications;
using PfsDomain.Interfaces.Repositories;

namespace PfsApplications.Applications
{
    public class AccountApp : IAccountApp
    {
        private readonly IAccountRepo _repository;
        public AccountApp(IAccountRepo repository)
        {
            _repository = repository;
        }
    }
}
