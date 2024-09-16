using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OtpRepository : RepositoryBase<Otp>, IOtpRepository
    {
        public OtpRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            
        }

        public void SaveOtp(Otp otp) => Create(otp);

        public Otp VerifyOtp(string requestId, bool trackChanges) =>
            FindByCondition(c => c.requestId.Equals(requestId), trackChanges)
            .SingleOrDefault();
    }
}
