using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void UpdateUser(User user);
        User GetUserByPhone(string phone, bool trackChanges);
        User GetUserById(Guid userId, bool trackChanges);
        IEnumerable<User> GetAllUsers(bool trackChanges);
    }
}
