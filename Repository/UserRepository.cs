using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) 
        {

        }

        public void CreateUser(User user) => Create(user);
        public void UpdateUser(User user) => Update(user);
        public User GetUserByPhone(string phone, bool trackChanges) =>
            FindByCondition(e => e.PhoneNumber.Equals(phone), trackChanges)
            .SingleOrDefault();
        public User GetUserById(Guid userId, bool trackChanges) =>
            FindByCondition(e => e.Id.Equals(userId), trackChanges)
            .SingleOrDefault();
        public IEnumerable<User>GetAllUsers(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(e => e.Id)
            .ToList();
    }
}
