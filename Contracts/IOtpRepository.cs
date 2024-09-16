using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IOtpRepository
    {
        void SaveOtp(Otp otp);
        Otp VerifyOtp(string requestId, bool trackChanges);
    }
}
