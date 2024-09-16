using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IOtpRepository> _otpRepository;
        public RepositoryManager(RepositoryContext repositoryContext) 
        { 
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _otpRepository = new Lazy<IOtpRepository>(() => new OtpRepository(repositoryContext));
        }
        public IUserRepository User => _userRepository.Value;
        public IOtpRepository OtpRepository => _otpRepository.Value;
        public void Save() => _repositoryContext.SaveChanges();
    }
}
