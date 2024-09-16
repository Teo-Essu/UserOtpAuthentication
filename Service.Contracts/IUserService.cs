using Entities.Models;

namespace Service.Contracts
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<string> VerifyOtp(string requestId, string code, bool trackChanges);
        OtpResponse SaveOtp(OtpResponse otp);
        IEnumerable<User> GetAllUsers(bool trackChanges);
    }
}
