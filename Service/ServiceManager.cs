using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, IConfiguration configuration)
        {
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(repositoryManager, logger, mapper, configuration));
        }
        public IUserService UserService => _userService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;

    }
}
