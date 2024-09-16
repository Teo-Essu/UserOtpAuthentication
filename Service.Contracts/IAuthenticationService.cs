using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<TokenDto> CreateToken(Guid userId,bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
    }
}
