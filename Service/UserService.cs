using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public UserService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var existingUser = _repository.User.GetUserByPhone((string?)user.PhoneNumber, trackChanges: false);
            if (existingUser != null)
                return existingUser;

            _repository.User.CreateUser(user);
            _repository.Save();

            return user;
        }

        public async Task<string> VerifyOtp (string requestId, string code, bool trackChanges)
        {
            var recievedOtp = _repository.OtpRepository.VerifyOtp(requestId, trackChanges);

            if (recievedOtp is null)
                throw new Exception($"Request ID: {requestId} can not be found");

            return requestId;
        }

        public OtpResponse SaveOtp(OtpResponse otpResponse)
        {
            _repository.OtpRepository.SaveOtp(otpResponse.data.otp);
            _repository.Save();

            return otpResponse;
        }

        public IEnumerable<User> GetAllUsers(bool trackChanges)
        {
            var users = _repository.User.GetAllUsers(trackChanges);

            return users;
        }

    }
}
